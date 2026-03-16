# Software Development 2 Assignment 2: Forge Factory Game

## 1.0 User Stories 

High priority:
* The player should be able to drag tiles that lock to the game grid

* The player should be able to generate balance per in game tick when a forge tile is connected to a mine tile

* The player should be able to place refiners inbetween a mine and a forge tile to multiply the balance value generated per in game tick

* The player should be able to read the current balance from the top of the screen and it should update with each in game tick

* The player should be able to purchase tiles from the shop window that will then appear in the inventory window

* The player should be able to complete goals of incremental difficulty to progress through the game 

Medium Priority:
* The player should be able to adjust the position of tiles after they have been placed

* The player should unlock new types of tiles as they progress through the game

* The player should be able to drag tiles off of the grid, when this happens the tiles should return to the inventory

Low Priority:
* The player should be get audio feedback when performing actions in the game

* The player should receive notifications when a goal is completed
## 2.0 System Requirements

Functional Requirements 

* The game will take place on a eight by eight grid

* Tiles can be placed in unoccupied grid cells

* A tick mechanism will be utilised to update the balance value

* Every tick, tile chains will evaluate tile chains placed on the grid

* The value of tile chains will be calculated by multiplying the mines base value by the value of the refiners 

* Every tick the system will check if the goal has been met

* The goal is multiplied incrementally after it has been met

Non-Functional Requirements

* The user will control the game using a computer mouse

* The game will be utilise the unity game engine

* The game will be responsive and any changes to the gameplay grid will be implemented before the next tick
## 3.0 Scrum Backlog 
![backlog1](./ReportImages/ScrumBacklog1.png)
![backlog2](./ReportImages/ScrumBacklog2.png)
Above is the complete scrum backlog for this project. In this section, backlog tasks will be expanded upon and assigned a priority level

### High Priority:
#### Grid System 
An eight by eight grid should be generated when the scene loads, each grid cell should be able to be accessed via its grid co-ordinates

#### Tile Placement
Tiles should be able to be dragged from the inventory onto the grid, the tile should snap into position if over an empty cell. If the cell is not empty, the tile should return to the inventory.

#### Tile Repositioning 
Already placed cells should be able to be dragged from one cell to another. If a tile is dragged off of the grid it is returned to the inventory.

#### Mine Tile

#### Refiner Tile

#### Forge Tile

#### Tick System

#### Goal System 

#### Tile Shop

#### Tile Inventory 

#### Return Tiles to Inventory

#### Tile Unlock System

#### Game Audio

#### Notification System


## 4.0 Design Breakdown

## 5.0 Functional Breakdown

## 6.0 Project Management
 
## 7.0 Coding Techniques and Software Tools

## 8.0 Testing

## 9.0 References