from __future__ import annotations

from pathlib import Path

from appdirs import AppDirs

local_dirs = AppDirs("Corruptovania", False, roaming=False)
roaming_dirs = AppDirs("Corruptovania", False, roaming=True)


def local_data_dir() -> Path:
    return Path(local_dirs.user_data_dir)


def roaming_data_dir() -> Path:
    return Path(roaming_dirs.user_config_dir)
