from __future__ import annotations

import importlib.util
import sys
from pathlib import Path

import pytest


def _load_module():
    module_path = (
        Path(__file__).resolve().parents[2].joinpath("tools", "prime3_patcher", "build_macos_toolchain.py")
    )
    spec = importlib.util.spec_from_file_location("build_macos_toolchain", module_path)
    assert spec is not None
    assert spec.loader is not None
    module = importlib.util.module_from_spec(spec)
    sys.modules[spec.name] = module
    spec.loader.exec_module(module)
    return module


def test_parse_dotnet_runtime_version() -> None:
    module = _load_module()
    output = """\
Microsoft.NETCore.App 6.0.36 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.AspNetCore.App 8.0.7 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 8.0.7 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 8.0.11 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
"""

    assert module.parse_dotnet_runtime_version(output) == "8.0.11"


def test_parse_dotnet_runtime_version_requires_supported_family() -> None:
    module = _load_module()
    output = "Microsoft.NETCore.App 6.0.36 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]"

    with pytest.raises(RuntimeError, match="Microsoft.NETCore.App 8.0 runtime"):
        module.parse_dotnet_runtime_version(output)


def test_dotnet_runtime_arch() -> None:
    module = _load_module()

    assert module.dotnet_runtime_arch("x86_64") == "x64"
    assert module.dotnet_runtime_arch("arm64") == "arm64"


def test_is_macho(tmp_path: Path) -> None:
    module = _load_module()
    macho_file = tmp_path.joinpath("lib.dylib")
    text_file = tmp_path.joinpath("plain.txt")

    macho_file.write_bytes(b"\xca\xfe\xba\xbfrest")
    text_file.write_text("hello")

    assert module.is_macho(macho_file) is True
    assert module.is_macho(text_file) is False


def test_macho_load_commands_skips_all_fat_binary_headers(
    tmp_path: Path,
    monkeypatch: pytest.MonkeyPatch,
) -> None:
    module = _load_module()
    macho_path = tmp_path.joinpath("liblzokay.dylib")

    class FakeResult:
        stdout = f"""{macho_path} (architecture x86_64):
\t@rpath/liblzokay.dylib (compatibility version 0.0.0, current version 0.0.0)
\t/usr/lib/libSystem.B.dylib (compatibility version 1.0.0, current version 1351.0.0)
{macho_path} (architecture arm64):
\t@rpath/liblzokay.dylib (compatibility version 0.0.0, current version 0.0.0)
\t/usr/lib/libSystem.B.dylib (compatibility version 1.0.0, current version 1351.0.0)
"""

    def fake_run(command, *, check, capture_output, text):
        assert command == ["otool", "-L", str(macho_path)]
        assert check is True
        assert capture_output is True
        assert text is True
        return FakeResult()

    monkeypatch.setattr(module.subprocess, "run", fake_run)

    assert module.macho_load_commands(macho_path) == (
        "@rpath/liblzokay.dylib",
        "/usr/lib/libSystem.B.dylib",
        "@rpath/liblzokay.dylib",
        "/usr/lib/libSystem.B.dylib",
    )


def _write_runtime_file(runtime_root: Path, relative_path: str, contents: bytes = b"stub") -> Path:
    path = runtime_root.joinpath(relative_path)
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_bytes(contents)
    return path


def test_copy_runtime_tree_preserves_arch_specific_managed_files(tmp_path: Path) -> None:
    module = _load_module()
    source = tmp_path.joinpath("source")
    output = tmp_path.joinpath("output")
    source.mkdir()
    _write_runtime_file(source, "shared/Microsoft.NETCore.App/8.0.1/Microsoft.CSharp.dll", b"x64-r2r")

    module.copy_runtime_tree(source, output)

    assert output.joinpath("shared/Microsoft.NETCore.App/8.0.1/Microsoft.CSharp.dll").read_bytes() == b"x64-r2r"


def test_copy_runtime_tree_uses_copy2_and_preserves_symlinks(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()
    source = tmp_path.joinpath("source")
    output = tmp_path.joinpath("output")
    source.mkdir()
    calls = {}

    def fake_copytree(src, dst, *, symlinks, copy_function):
        calls["src"] = src
        calls["dst"] = dst
        calls["symlinks"] = symlinks
        calls["copy_function"] = copy_function

    monkeypatch.setattr(module.shutil, "copytree", fake_copytree)

    module.copy_runtime_tree(source, output)

    assert calls["src"] == source
    assert calls["dst"] == output
    assert calls["symlinks"] is True
    assert calls["copy_function"] == module.shutil.copy2


def test_validate_runtime_tree_requires_every_expected_file(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()
    tmp_path.joinpath("dotnet").write_bytes(b"\xca\xfe\xba\xbfstub")
    monkeypatch.setattr(module, "is_macho", lambda path: True)
    monkeypatch.setattr(module, "assert_single_arch", lambda path, expected_arch: None)
    monkeypatch.setattr(module, "is_user_executable", lambda path: True)

    with pytest.raises(RuntimeError, match="Missing required runtime binary"):
        module.validate_runtime_tree(tmp_path, "x86_64")


def test_validate_runtime_tree_accepts_arch_specific_managed_dlls(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()
    _write_runtime_file(tmp_path, "dotnet")
    for filename in module.REQUIRED_RUNTIME_BINARIES[1:]:
        _write_runtime_file(tmp_path, f"shared/Microsoft.NETCore.App/8.0.11/{filename}")
    _write_runtime_file(tmp_path, "shared/Microsoft.NETCore.App/8.0.11/Microsoft.CSharp.dll", b"x64-r2r")

    monkeypatch.setattr(module, "is_macho", lambda path: path.name in {"dotnet", "libhostfxr.dylib"})
    monkeypatch.setattr(module, "is_user_executable", lambda path: True)
    calls = []

    def fake_assert_single_arch(path: Path, expected_arch: str) -> None:
        calls.append((path.name, expected_arch))

    monkeypatch.setattr(module, "assert_single_arch", fake_assert_single_arch)

    module.validate_runtime_tree(tmp_path, "x86_64")

    assert ("dotnet", "x86_64") in calls
    assert ("libhostfxr.dylib", "x86_64") in calls
    assert all(name != "Microsoft.CSharp.dll" for name, _ in calls)


def test_validate_runtime_tree_rejects_wrong_arch_in_arm64_tree(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()
    _write_runtime_file(tmp_path, "dotnet")
    for filename in module.REQUIRED_RUNTIME_BINARIES[1:]:
        _write_runtime_file(tmp_path, f"shared/Microsoft.NETCore.App/8.0.11/{filename}")

    monkeypatch.setattr(module, "is_macho", lambda path: path.name == "libhostpolicy.dylib")
    monkeypatch.setattr(module, "is_user_executable", lambda path: True)

    def fake_assert_single_arch(path: Path, expected_arch: str) -> None:
        raise RuntimeError(f"{path} unexpectedly contains x86_64 in {expected_arch} runtime tree")

    monkeypatch.setattr(module, "assert_single_arch", fake_assert_single_arch)

    with pytest.raises(RuntimeError, match="unexpectedly contains x86_64"):
        module.validate_runtime_tree(tmp_path, "arm64")


def test_validate_runtime_tree_rejects_wrong_arch_in_x64_tree(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()
    _write_runtime_file(tmp_path, "dotnet")
    for filename in module.REQUIRED_RUNTIME_BINARIES[1:]:
        _write_runtime_file(tmp_path, f"shared/Microsoft.NETCore.App/8.0.11/{filename}")

    monkeypatch.setattr(module, "is_macho", lambda path: path.name == "libclrjit.dylib")
    monkeypatch.setattr(module, "is_user_executable", lambda path: True)

    def fake_assert_single_arch(path: Path, expected_arch: str) -> None:
        raise RuntimeError(f"{path} unexpectedly contains arm64 in {expected_arch} runtime tree")

    monkeypatch.setattr(module, "assert_single_arch", fake_assert_single_arch)

    with pytest.raises(RuntimeError, match="unexpectedly contains arm64"):
        module.validate_runtime_tree(tmp_path, "x86_64")


def test_build_hpatchz_passes_arch_flags_through_environment(
    tmp_path: Path,
    monkeypatch: pytest.MonkeyPatch,
) -> None:
    module = _load_module()
    source_root = tmp_path.joinpath("HDiffPatch")
    build_root = tmp_path.joinpath("build")
    output_path = tmp_path.joinpath("hpatchz")
    source_root.mkdir()
    build_root.mkdir()

    calls = []

    monkeypatch.setattr(module, "clone_source", lambda source, checkout_root: source_root)
    monkeypatch.setattr(module, "clone_hdiffpatch_dependencies", lambda checkout_root: None)
    monkeypatch.setattr(module, "merge_binary", lambda first, second, output: None)

    def fake_run(command, *, cwd=None, env=None):
        calls.append((command, cwd, env))
        if command == ["make", "-j", "hpatchz"]:
            source_root.joinpath("hpatchz").write_bytes(b"binary")

    monkeypatch.setattr(module, "run", fake_run)

    module.build_hpatchz(
        tmp_path.joinpath("sources"),
        build_root,
        output_path,
        "12.0",
    )

    build_calls = [
        (command, env)
        for command, _, env in calls
        if command == ["make", "-j", "hpatchz"]
    ]

    assert len(build_calls) == 2

    for command, env in build_calls:
        assert command == ["make", "-j", "hpatchz"]
        assert env is not None
        assert env["CC"] == "clang"
        assert env["CXX"] == "clang++"
        assert "-arch" in env["CFLAGS"]
        assert "-mmacosx-version-min=12.0" in env["CFLAGS"]
        assert env["CXXFLAGS"] == env["CFLAGS"]
        assert all(not item.startswith(("CFLAGS=", "CXXFLAGS=", "LDFLAGS=")) for item in command)


def test_patch_wit_setup_script_replaces_gnu_awk_gensub(tmp_path: Path) -> None:
    module = _load_module()
    project_root = tmp_path.joinpath("project")
    project_root.mkdir()
    setup_path = project_root.joinpath("setup.sh")

    setup_path.write_text(
        r"""gcc -E system.c \
    | awk -F= '/^result_/ {printf("%s := %s\n",substr($1,8),gensub(/"/,"","g",$2))}' \
    > Makefile.setup
""",
        encoding="utf-8",
    )

    module.patch_wit_setup_script(project_root)

    patched = setup_path.read_text(encoding="utf-8")
    assert "gensub" not in patched
    assert 'gsub(/"/,"",value)' in patched
    assert 'printf("%s := %s\\n",substr($1,8),value)' in patched


def test_patch_wit_save_restore_alignment_removes_packed_pointer_table(
    tmp_path: Path,
) -> None:
    module = _load_module()
    project_root = tmp_path.joinpath("project")
    dclib_root = project_root.joinpath("dclib")
    dclib_root.mkdir(parents=True)

    header_path = dclib_root.joinpath("dclib-basics.h")
    header_path.write_text(
        """typedef struct SaveRestoreTab_t
{
    unsigned int offset;
    unsigned int size;
    const char *name;
}
__attribute__ ((packed)) SaveRestoreTab_t;
""",
        encoding="utf-8",
    )

    module.patch_wit_save_restore_alignment(project_root)

    patched = header_path.read_text(encoding="utf-8")
    assert "__attribute__ ((packed)) SaveRestoreTab_t;" not in patched
    assert "\nSaveRestoreTab_t;" in patched


def test_patch_wit_sizeof_info_alignment_removes_packed_pointer_table(
    tmp_path: Path,
) -> None:
    module = _load_module()
    project_root = tmp_path.joinpath("project")
    dclib_root = project_root.joinpath("dclib")
    dclib_root.mkdir(parents=True)

    header_path = dclib_root.joinpath("dclib-basics.h")
    header_path.write_text(
        """typedef struct sizeof_info_t
{
    int size;
    const char *name;
}
__attribute__ ((packed)) sizeof_info_t;
""",
        encoding="utf-8",
    )

    module.patch_wit_sizeof_info_alignment(project_root)

    patched = header_path.read_text(encoding="utf-8")
    assert "__attribute__ ((packed)) sizeof_info_t;" not in patched
    assert "\nsizeof_info_t;" in patched


def test_publish_mp3_randomizer_uses_portable_framework_dependent_publish(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()
    build_root = tmp_path.joinpath("build")
    output_dir = tmp_path.joinpath("output")
    output_dir.mkdir()
    publish_root = build_root.joinpath("publish-portable")
    commands = []

    def fake_run(command: list[str], *, cwd=None, env=None) -> None:
        del cwd, env
        commands.append(command)
        publish_root.mkdir(parents=True, exist_ok=True)
        publish_root.joinpath("MP3Randomizer.dll").write_text("dll")
        publish_root.joinpath("MP3Randomizer.deps.json").write_text("{}")
        publish_root.joinpath("MP3Randomizer.runtimeconfig.json").write_text("{}")

    monkeypatch.setattr(module, "run", fake_run)

    module.publish_mp3_randomizer(build_root, output_dir)

    assert any("-p:UseAppHost=false" in command for command in commands)
    assert all("-r" not in command for command in commands)
    assert output_dir.joinpath("MP3Randomizer.dll").is_file()
    assert output_dir.joinpath("MP3Randomizer.deps.json").is_file()
    assert output_dir.joinpath("MP3Randomizer.runtimeconfig.json").is_file()


def test_download_dotnet_install_script_rejects_unexpected_checksum(tmp_path: Path, monkeypatch) -> None:
    module = _load_module()

    class FakeResponse:
        def __enter__(self):
            return self

        def __exit__(self, exc_type, exc, tb) -> None:
            del exc_type, exc, tb

        def read(self) -> bytes:
            return b"wrong-script"

    monkeypatch.setattr(module.urllib.request, "urlopen", lambda url: FakeResponse())

    with pytest.raises(RuntimeError, match="Unexpected checksum for dotnet-install.sh"):
        module.download_dotnet_install_script(tmp_path)
