from __future__ import annotations

import importlib.util
import os
import subprocess
import sys
from pathlib import Path

import pytest


def _load_module():
    module_path = (
        Path(__file__).resolve().parents[2]
        .joinpath("tools", "validate_macos_universal2.py")
    )
    spec = importlib.util.spec_from_file_location(
        "validate_macos_universal2",
        module_path,
    )
    assert spec is not None
    assert spec.loader is not None

    module = importlib.util.module_from_spec(spec)
    sys.modules[spec.name] = module
    spec.loader.exec_module(module)
    return module


def test_find_helper_accepts_pyinstaller_file_aliases(tmp_path: Path) -> None:
    module = _load_module()
    bundle = tmp_path.joinpath("Corruptovania.app")
    suffix = "data/gollop_mp3_patcher/macos/MP3Randomizer.dll"

    resource_path = bundle.joinpath("Contents", "Resources", suffix)
    framework_path = bundle.joinpath("Contents", "Frameworks", suffix)

    resource_path.parent.mkdir(parents=True)
    framework_path.parent.mkdir(parents=True)
    resource_path.write_bytes(b"managed assembly")
    os.link(resource_path, framework_path)

    result = module.find_helper(bundle, suffix)

    assert result.samefile(resource_path)
    assert result == resource_path


def test_find_helper_rejects_distinct_duplicate_files(tmp_path: Path) -> None:
    module = _load_module()
    bundle = tmp_path.joinpath("Corruptovania.app")
    suffix = "data/gollop_mp3_patcher/macos/MP3Randomizer.dll"

    resource_path = bundle.joinpath("Contents", "Resources", suffix)
    framework_path = bundle.joinpath("Contents", "Frameworks", suffix)

    resource_path.parent.mkdir(parents=True)
    framework_path.parent.mkdir(parents=True)
    resource_path.write_bytes(b"first")
    framework_path.write_bytes(b"second")

    with pytest.raises(RuntimeError, match="multiple distinct matches"):
        module.find_helper(bundle, suffix)


def test_otool_loads_skips_every_fat_binary_header(
    tmp_path: Path,
    monkeypatch: pytest.MonkeyPatch,
) -> None:
    module = _load_module()
    macho_path = tmp_path.joinpath("helper")

    output = f"""{macho_path} (architecture x86_64):
\t@rpath/helper (compatibility version 0.0.0, current version 0.0.0)
\t/usr/lib/libSystem.B.dylib (compatibility version 1.0.0, current version 1351.0.0)
{macho_path} (architecture arm64):
\t@rpath/helper (compatibility version 0.0.0, current version 0.0.0)
\t/usr/lib/libSystem.B.dylib (compatibility version 1.0.0, current version 1351.0.0)
"""

    def fake_run(command: list[str]) -> subprocess.CompletedProcess[str]:
        assert command == ["otool", "-L", str(macho_path)]
        return subprocess.CompletedProcess(
            command,
            0,
            stdout=output,
            stderr="",
        )

    monkeypatch.setattr(module, "run", fake_run)

    assert module.otool_loads(macho_path) == [
        "@rpath/helper",
        "/usr/lib/libSystem.B.dylib",
        "@rpath/helper",
        "/usr/lib/libSystem.B.dylib",
    ]
