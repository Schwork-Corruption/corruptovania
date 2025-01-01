from __future__ import annotations

from typing import TYPE_CHECKING

from randovania.resolver.bootstrap import MetroidBootstrap

if TYPE_CHECKING:
    from randovania.game_description.resources.resource_database import ResourceDatabase
    from randovania.games.prime3.layout.corruption_configuration import CorruptionConfiguration


class CorruptionBootstrap(MetroidBootstrap):
    def _get_enabled_misc_resources(
        self, configuration: CorruptionConfiguration, resource_database: ResourceDatabase
    ) -> set[str]:
        enabled_resources = set()
        if configuration.teleporters.skip_final_bosses:
            enabled_resources.add("PhaazeSkip")
        return enabled_resources
