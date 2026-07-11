from __future__ import annotations

import importlib.util
import sys
from pathlib import Path


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
Microsoft.AspNetCore.App 8.0.7 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 8.0.7 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
"""

    assert module.parse_dotnet_runtime_version(output) == "8.0.7"


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
