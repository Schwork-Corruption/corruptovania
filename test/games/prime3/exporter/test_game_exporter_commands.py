from __future__ import annotations

import os
import subprocess
from pathlib import Path

import pytest

from randovania.games.prime3.exporter.game_exporter import (
    CorruptionGameExportParams,
    CorruptionOutputFormats,
    _build_hpatchz_command,
    _build_randomizer_command,
    _build_wit_command,
    _run_process,
)
from randovania.games.prime3.exporter.toolchain import Prime3Toolchain


def _toolchain(*, randomizer_command: tuple[str, ...] = ("randomizer",)) -> Prime3Toolchain:
    return Prime3Toolchain(
        randomizer_command=randomizer_command,
        hpatchz_command=("hpatchz",),
        wit_command=("wit",),
        extractor_command=(),
        uses_python_nod=True,
    )


def test_build_hpatchz_command() -> None:
    command = _build_hpatchz_command(_toolchain(), Path("main.dol"), Path("main.hdiff"))
    assert command == ("hpatchz", "-f", "main.dol", "main.hdiff", "main.dol")


def test_build_randomizer_command() -> None:
    patch_data = {
        "seed": "SEED123",
        "starting_items": "Missile Expansion Morph Ball",
        "starting_location": "Landing Site",
        "random_door_colors": True,
        "random_welding_colors": False,
        "missile_required_mains": True,
        "ship_missile_required_mains": False,
        "phaaze_skip": True,
    }

    command = _build_randomizer_command(
        _toolchain(randomizer_command=("dotnet", "MP3Randomizer.dll")),
        patch_data,
        Path("input"),
        Path("output"),
    )

    assert command == (
        "dotnet",
        "MP3Randomizer.dll",
        "--input-path",
        f"input{os.sep}",
        "--output-path",
        f"output{os.sep}",
        "--layout",
        "SEED123",
        "--starting-items",
        "Missile",
        "Expansion",
        "Morph",
        "Ball",
        "--starting-location",
        "Landing",
        "Site",
        "--random-door-colors",
        "--hyper-hints",
        "--fast-flying",
        "--require-launcher",
        "--phaaze-skip",
    )


def test_build_wit_command() -> None:
    export_params = CorruptionGameExportParams(
        spoiler_output=None,
        input_path=Path("input.iso"),
        output_path=Path("out.wbfs"),
        output_format=CorruptionOutputFormats.WBFS,
        mp3_update=False,
    )

    command = _build_wit_command(_toolchain(), Path("DATA"), export_params)
    assert command == ("wit", "COPY", "-B", "-z", "--trunc", "--auto-split", "--overwrite", "DATA", "out.wbfs")


def test_run_process_wraps_tool_failures(monkeypatch: pytest.MonkeyPatch) -> None:
    def fake_run(command, check, env):
        raise subprocess.CalledProcessError(returncode=23, cmd=command)

    monkeypatch.setattr("subprocess.run", fake_run)

    with pytest.raises(RuntimeError, match="Prime 3 helper failed \\(randomizer, exit code 23\\)"):
        _run_process(("randomizer", "--flag"), env={"DOTNET_ROOT": "/tmp/dotnet"})
