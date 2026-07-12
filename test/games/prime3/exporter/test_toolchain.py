from __future__ import annotations

from pathlib import Path

import pytest

from randovania.games.prime3.exporter.toolchain import (
    Prime3Toolchain,
    extract_prime3_disc_image,
    resolve_prime3_toolchain,
)


def test_resolve_prime3_toolchain_windows(tmp_path: Path, monkeypatch: pytest.MonkeyPatch) -> None:
    patcher_root = tmp_path.joinpath("gollop_mp3_patcher")
    patcher_root.mkdir()
    for relative_path in [
        "MP3Randomizer.exe",
        "hpatchz.exe",
        "wit/bin/wit.exe",
        "nodtool/nodtool.exe",
    ]:
        file_path = patcher_root.joinpath(relative_path)
        file_path.parent.mkdir(parents=True, exist_ok=True)
        file_path.write_text("")

    monkeypatch.setattr("platform.system", lambda: "Windows")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    toolchain = resolve_prime3_toolchain()

    assert toolchain.randomizer_command == (str(patcher_root.joinpath("MP3Randomizer.exe")),)
    assert toolchain.hpatchz_command == (str(patcher_root.joinpath("hpatchz.exe")),)
    assert toolchain.wit_command == (str(patcher_root.joinpath("wit", "bin", "wit.exe")),)
    assert toolchain.extractor_command == (str(patcher_root.joinpath("nodtool", "nodtool.exe")), "extract")
    assert toolchain.uses_python_nod is False


def test_resolve_prime3_toolchain_macos(tmp_path: Path, monkeypatch: pytest.MonkeyPatch) -> None:
    macos_root = tmp_path.joinpath("gollop_mp3_patcher", "macos")
    macos_root.mkdir(parents=True)
    for relative_path in [
        "MP3Randomizer.dll",
        "MP3Randomizer.deps.json",
        "MP3Randomizer.runtimeconfig.json",
        "dotnet-arm64/dotnet",
        "hpatchz",
        "wit",
        "liblzokay.dylib",
    ]:
        file_path = macos_root.joinpath(relative_path)
        file_path.parent.mkdir(parents=True, exist_ok=True)
        file_path.write_text("")

    monkeypatch.setattr("platform.system", lambda: "Darwin")
    monkeypatch.setattr("platform.machine", lambda: "arm64")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    toolchain = resolve_prime3_toolchain()

    assert toolchain.randomizer_command == (
        str(macos_root.joinpath("dotnet-arm64", "dotnet")),
        str(macos_root.joinpath("MP3Randomizer.dll")),
    )
    assert toolchain.hpatchz_command == (str(macos_root.joinpath("hpatchz")),)
    assert toolchain.wit_command == (str(macos_root.joinpath("wit")),)
    assert toolchain.extractor_command == ()
    assert toolchain.uses_python_nod is True
    assert toolchain.randomizer_environment["DOTNET_ROOT"] == str(macos_root.joinpath("dotnet-arm64"))
    assert toolchain.randomizer_environment["DOTNET_MULTILEVEL_LOOKUP"] == "0"
    assert toolchain.lzokay_library == macos_root.joinpath("liblzokay.dylib")


def test_resolve_prime3_toolchain_macos_x64(tmp_path: Path, monkeypatch: pytest.MonkeyPatch) -> None:
    macos_root = tmp_path.joinpath("gollop_mp3_patcher", "macos")
    macos_root.mkdir(parents=True)
    for relative_path in [
        "MP3Randomizer.dll",
        "MP3Randomizer.deps.json",
        "MP3Randomizer.runtimeconfig.json",
        "dotnet-x64/dotnet",
        "hpatchz",
        "wit",
        "liblzokay.dylib",
    ]:
        file_path = macos_root.joinpath(relative_path)
        file_path.parent.mkdir(parents=True, exist_ok=True)
        file_path.write_text("")

    monkeypatch.setattr("platform.system", lambda: "Darwin")
    monkeypatch.setattr("platform.machine", lambda: "x86_64")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    toolchain = resolve_prime3_toolchain()

    assert toolchain.randomizer_command == (
        str(macos_root.joinpath("dotnet-x64", "dotnet")),
        str(macos_root.joinpath("MP3Randomizer.dll")),
    )
    assert toolchain.randomizer_environment["DOTNET_ROOT"] == str(macos_root.joinpath("dotnet-x64"))


def test_resolve_prime3_toolchain_macos_normalizes_aarch64(tmp_path: Path, monkeypatch: pytest.MonkeyPatch) -> None:
    macos_root = tmp_path.joinpath("gollop_mp3_patcher", "macos")
    macos_root.mkdir(parents=True)
    for relative_path in [
        "MP3Randomizer.dll",
        "MP3Randomizer.deps.json",
        "MP3Randomizer.runtimeconfig.json",
        "dotnet-arm64/dotnet",
        "hpatchz",
        "wit",
        "liblzokay.dylib",
    ]:
        file_path = macos_root.joinpath(relative_path)
        file_path.parent.mkdir(parents=True, exist_ok=True)
        file_path.write_text("")

    monkeypatch.setattr("platform.system", lambda: "Darwin")
    monkeypatch.setattr("platform.machine", lambda: "aarch64")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    toolchain = resolve_prime3_toolchain()

    assert toolchain.randomizer_command[0] == str(macos_root.joinpath("dotnet-arm64", "dotnet"))


def test_resolve_prime3_toolchain_macos_normalizes_amd64(tmp_path: Path, monkeypatch: pytest.MonkeyPatch) -> None:
    macos_root = tmp_path.joinpath("gollop_mp3_patcher", "macos")
    macos_root.mkdir(parents=True)
    for relative_path in [
        "MP3Randomizer.dll",
        "MP3Randomizer.deps.json",
        "MP3Randomizer.runtimeconfig.json",
        "dotnet-x64/dotnet",
        "hpatchz",
        "wit",
        "liblzokay.dylib",
    ]:
        file_path = macos_root.joinpath(relative_path)
        file_path.parent.mkdir(parents=True, exist_ok=True)
        file_path.write_text("")

    monkeypatch.setattr("platform.system", lambda: "Darwin")
    monkeypatch.setattr("platform.machine", lambda: "AMD64")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    toolchain = resolve_prime3_toolchain()

    assert toolchain.randomizer_command[0] == str(macos_root.joinpath("dotnet-x64", "dotnet"))


def test_resolve_prime3_toolchain_macos_rejects_unknown_architecture(
    tmp_path: Path, monkeypatch: pytest.MonkeyPatch
) -> None:
    macos_root = tmp_path.joinpath("gollop_mp3_patcher", "macos")
    macos_root.mkdir(parents=True)
    monkeypatch.setattr("platform.system", lambda: "Darwin")
    monkeypatch.setattr("platform.machine", lambda: "mips64")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    with pytest.raises(RuntimeError, match="Unsupported macOS architecture"):
        resolve_prime3_toolchain()


def test_resolve_prime3_toolchain_macos_requires_selected_runtime(
    tmp_path: Path, monkeypatch: pytest.MonkeyPatch
) -> None:
    macos_root = tmp_path.joinpath("gollop_mp3_patcher", "macos")
    macos_root.mkdir(parents=True)
    for relative_path in [
        "MP3Randomizer.dll",
        "MP3Randomizer.deps.json",
        "MP3Randomizer.runtimeconfig.json",
        "hpatchz",
        "wit",
        "liblzokay.dylib",
    ]:
        file_path = macos_root.joinpath(relative_path)
        file_path.parent.mkdir(parents=True, exist_ok=True)
        file_path.write_text("")

    monkeypatch.setattr("platform.system", lambda: "Darwin")
    monkeypatch.setattr("platform.machine", lambda: "arm64")
    monkeypatch.setattr("randovania.get_data_path", lambda: tmp_path)

    with pytest.raises(FileNotFoundError, match="Missing bundled macOS dotnet runtime"):
        resolve_prime3_toolchain()


def test_extract_prime3_disc_image_uses_subprocess_for_windows(
    tmp_path: Path, monkeypatch: pytest.MonkeyPatch
) -> None:
    called = {}

    def fake_run(command: list[str], check: bool) -> None:
        called["command"] = command
        called["check"] = check

    monkeypatch.setattr("subprocess.run", fake_run)

    command = ("nodtool", "extract")
    extract_prime3_disc_image(
        Prime3Toolchain(
            randomizer_command=(),
            hpatchz_command=(),
            wit_command=(),
            extractor_command=command,
            uses_python_nod=False,
        ),
        tmp_path.joinpath("input.iso"),
        tmp_path.joinpath("extract"),
        lambda _message, _progress: None,
    )

    assert called["command"] == [*command, str(tmp_path.joinpath("input.iso")), str(tmp_path.joinpath("extract"))]
    assert called["check"] is True


def test_extract_prime3_disc_image_uses_python_nod(tmp_path: Path, monkeypatch: pytest.MonkeyPatch) -> None:
    callback = None
    extracted = {}

    class FakeContext:
        def set_progress_callback(self, progress_callback):
            nonlocal callback
            callback = progress_callback

    class FakePartition:
        def extract_to_directory(self, destination: str, context: FakeContext) -> None:
            extracted["destination"] = destination
            extracted["context"] = context
            Path(destination).joinpath("DATA", "files").mkdir(parents=True)
            Path(destination).joinpath("DATA", "sys").mkdir(parents=True)

    class FakeDisc:
        def get_data_partition(self) -> FakePartition:
            return FakePartition()

    monkeypatch.setattr("nod.open_disc_from_image", lambda input_path: (FakeDisc(), True))
    monkeypatch.setattr("nod.ExtractionContext", FakeContext)

    def progress(message, value) -> None:
        del message, value

    extract_prime3_disc_image(
        Prime3Toolchain(
            randomizer_command=(),
            hpatchz_command=(),
            wit_command=(),
            extractor_command=(),
            uses_python_nod=True,
        ),
        tmp_path.joinpath("input.iso"),
        tmp_path.joinpath("extract"),
        progress,
    )

    assert callback is progress
    assert extracted["destination"] == str(tmp_path.joinpath("extract"))


def test_extract_prime3_disc_image_rejects_missing_wii_data_partition(
    tmp_path: Path, monkeypatch: pytest.MonkeyPatch
) -> None:
    class FakeDisc:
        def get_data_partition(self):
            return None

    monkeypatch.setattr("nod.open_disc_from_image", lambda input_path: (FakeDisc(), True))

    with pytest.raises(RuntimeError, match="Could not find a Wii data partition"):
        extract_prime3_disc_image(
            Prime3Toolchain(
                randomizer_command=(),
                hpatchz_command=(),
                wit_command=(),
                extractor_command=(),
                uses_python_nod=True,
            ),
            tmp_path.joinpath("input.iso"),
            tmp_path.joinpath("extract"),
            lambda _message, _progress: None,
        )


def test_extract_prime3_disc_image_rejects_missing_prime3_layout(
    tmp_path: Path, monkeypatch: pytest.MonkeyPatch
) -> None:
    class FakeContext:
        def set_progress_callback(self, progress_callback) -> None:
            del progress_callback

    class FakePartition:
        def extract_to_directory(self, destination: str, context) -> None:
            del context
            Path(destination).joinpath("DATA", "files").mkdir(parents=True)

    class FakeDisc:
        def get_data_partition(self) -> FakePartition:
            return FakePartition()

    monkeypatch.setattr("nod.open_disc_from_image", lambda input_path: (FakeDisc(), True))
    monkeypatch.setattr("nod.ExtractionContext", FakeContext)

    with pytest.raises(RuntimeError, match="DATA/files and DATA/sys"):
        extract_prime3_disc_image(
            Prime3Toolchain(
                randomizer_command=(),
                hpatchz_command=(),
                wit_command=(),
                extractor_command=(),
                uses_python_nod=True,
            ),
            tmp_path.joinpath("input.iso"),
            tmp_path.joinpath("extract"),
            lambda _message, _progress: None,
        )
