from __future__ import annotations

import dataclasses

from randovania.games.game import RandovaniaGame
from randovania.layout.base.base_configuration import BaseConfiguration


@dataclasses.dataclass(frozen=True)
class CorruptionConfiguration(BaseConfiguration):
    energy_per_tank: int = dataclasses.field(metadata={"min": 1, "max": 1000, "precision": 1})
    start_with_corrupted_hypermode: bool = False
    MP3Update: bool = False

    @classmethod
    def game_enum(cls) -> RandovaniaGame:
        return RandovaniaGame.METROID_PRIME_CORRUPTION

    def unsupported_features(self) -> list[str]:
        result = super().unsupported_features()
        pickup_state = self.standard_pickup_configuration.pickups_state
        if any(
            definition.name == "Ship Grapple" and state.num_included_in_starting_pickups > 0
            for definition, state in pickup_state.items()
        ):
            result.append("Ship Grapple cannot be a starting item.")
        return result
