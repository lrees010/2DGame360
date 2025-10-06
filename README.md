# 2DGame360
A demonstration for Singleton pattern

## Student Info
- Name: Lysander Reese
- ID: 01232389

## Pattern: Singleton
### Implementation
The Singleton pattern is used for the "GameManager" class, so that all the information and functions for the game's state is managed in one global instance. This "GameManager" script tracks variables like the amount of lives the player has, the score, and the amount of enemies killed. The script also stores a number of functions related to helping the game work; a function to increase the player's score by a provided amount, to lose a life, and to restart the game. These functions can all be called from other scripts that reference the GameManager instance, allowing a centralized area for the fundamental game mechanics. The "GameManager" instance is a public instance, allowing other scripts to reference it. If I didn't use a GameManager instance, each script would have to manually set up the conditions and way in that they perform basic actions like increasing score, which would be messy, unproductive, and slow down development time.

### Game Integration
Functions from the "GameManager" class are called often by other scripts. For example, in the "Enemy" script, once the enemy has taken sufficient damage (one bullet) and dies, it calls the "EnemyKilled" function from the "GameManager" class. This way, we can universalize what happens when an enemy dies, rather than handling it in the Enemy script. This will be useful if more enemy variants are added, and we want them to all perform the same universal function when they die. Additionally, if we want to change that behavior, we only have to change one part of the "GameManager" script, rather than changing a part of every enemy variant script. Regarding integration, the "EnemySpawner" script is able to directly access the player's score from the "GameManager" script at any time, and it uses that value to determine the rate at which enemies spawn. A collectible script is also able to add a declared amount to the player's score using the Singleton. If we did not have this Singleton, we would have to get score via some other uncentralized means. But, with the Singleton we are able to easily scale the project and coordinate between scripts with clear guidelines and practice. This would allow us in the future to easily add enemy variants, bullet variants, ship upgrades, and more. The "GameManager" also handles functions of reloading the level and refreshing the UI. This allows the replay buttons from the game over screen and win screen to easily reset the level when needed, without having to deal with refreshing the score, firerate, and other variables that increase across gameplay.

## Game Description
- Title: 2DGame360
- Controls: WASD, Left Click, Arrow Keys
- Objective: Reach a score of 2000

## Repository Stats
- Total Commits: 17
- Development Time: 19 Hours