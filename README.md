# Software Development 2 Assignment 3: Forge Factory Game


## Scrum Backlog for New Features

### Tile Sell System
Players will be able to right click any tile placed on the grid to sell it for 50% of its cost. When this occurs the tile is deleted from the grid area and the balance updates.

Success Criteria:
* Right clicking a placed tile deletes it from the grid and updates the balance by adding 50% of its cost 
* Right clicking an empty cell has no adverse effects
* Chains are re-evaluated after tile deletion

Tests:
* T1: Right-click a placed Mine tile and ensure it is removed from the grid
* T2: Verify the balance increases by exactly 50% of the tiles shop cost after selling
* T3: Right-click an empty cell and make sure nothing happens
* T4: Place a Mine-Forge chain, sell the Forge tile, verify balance stops generating

### Tick Speed Upgrade
A purchasable upgrade available in the shop panel that reduces the tick interval. 
Three tiers available costing 100, 300 and 750 balance. Minimum tick interval is 0.75 seconds.

Success Criteria:
* Button visible in shop panel displaying correct tier cost
* Button only clickable when balance is sufficient
* Each purchase reduces tick interval by 0.4 seconds
* Button displays MAX SPEED and disables after third upgrade

Tests:
* T5: Verify the upgrade button is greyed out when balance is below 100
* T6: Purchase the first upgrade and verify the tick interval decreases
* T7: Purchase all three upgrades and verify the button displays MAX SPEED


### Stats Panel
A panel displaying active chains, balance earned last tick, best chain value and total tiles placed. Updates every tick.

Definition of Done:
* Panel visible during gameplay
* All four statistics display correct values
* Values update after every tick

Tests:
* T8: Place one Mine-Forge chain and verify Active Chains displays 1
* T9: Verify Last Tick value matches the balance increase after a tick
* T10: Place two chains of different values and verify Best Chain shows the higher value
* T11: Place three tiles and verify Tiles Placed displays 3

## Design of new features

## Implementation of new features


![backlog1](./ReportImages/ScrumBacklog1.png)