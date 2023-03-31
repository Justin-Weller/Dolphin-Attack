# Dolphin-Attack

My prototype for Dolphin Attack was developed using the game engine Unity. The source files are in the folder "Dolphin Attack" and the executable file is in the folder "Build" (named "Dolphin Attack.exe"). Launching this exe in the build folder will launch the game and bring you to the start menu of the game.

**NOTE:** Importing two asset packages (cited below) resulted in two folders which may contain scripts that I did not write. I didn't use them at all but I felt I should make it known to you as the grader. These folders are under "Dolphin Attack">Assets and I added "IMPORTED" at the start of their file names. There are (non-coding) assets within those folders which I may use in the upcoming group portion of this course which is why I left that folder for the time being.

## Features

For the prototype, I've implemented a vertical slice of my original proposal which include the following features:

- Start menu (excluding the leaderboard). The player can either quit to desktop or start the game from here.
- Pause menu. The player can resume the game, restart the game, or exit to the main menu. It can be activated or deactivated in game with the "ESC" key.
- Pirate ship in the middle of a sea environment with a variety of platforms to allow for a highly maneuverable environment for the player.
- Player movement, with the key 'A' moving left, 'D' moving right, spacebar to jump, double jump by pressing spacebar a second time while in the air, and a dash using the left-shift button. Additionally, the player can drop through platforms by holding the 'S' key and pressing the spacebar.
- Player shooting, which can be executed by aiming with the mouse and firing bullets using the left mouse button.
- A death screen is triggered if the player falls into the sea, instantly killing their character.
- A few different SFX for pistol shots, dashes, and background ambience.

These features are fairly polished at this point and demonstrate most of the features that the player has at their disposal. This vertical slice prototype gives a good sense of how the final game will feel and if it were to be developed further in the group stage I would then proceed with implementing the core gameplay including the dolphin enemies, wave functionality, character selection screen, and leaderboard as specified in my proposal.

I considered implementing a dynamic camera to follow the character at a closer position, but that may limit visibility of the enemies when implemented in later stages, so for the moment I opted for a static camera visible of the entire environment and will test what works better in the group stage.

## Resources Used

Pirate character models:
https://assetstore.unity.com/packages/2d/characters/2d-8bit-pixel-character-pack-106860#description

2D Pirate ship pack:
https://assetstore.unity.com/packages/2d/textures-materials/2d-pirate-ship-pack-195444#content

Gunshot Audio:
https://www.youtube.com/watch?v=cGLjlRQPGzQ

Dash Audio:
https://www.youtube.com/watch?v=EFY9TX2Fghg

Ambience Audio:
https://www.youtube.com/watch?v=AH96SmNlGRY

"YOU DIED" Ending screen Image:
https://www.pngwing.com/en/free-png-vcksi

Health Image:
https://blackthornprod-games.itch.io/top-down-shooter-demo

Tutorial which aided in achieving one way platforms functionality:
https://www.youtube.com/watch?v=7rCUt6mqqE8

Unity forum which aided in implementing the dolphin's movement:
https://forum.unity.com/threads/how-to-calculate-force-needed-to-jump-towards-target-point.372288/#post-3424370

Dolphin Image:
http://clipart-library.com/img/939779.png

Menu Background Image: https://www.freepik.com/free-vector/tropical-island-with-treasure-chest-broken-pirate-ship-cartoon-sea-landscape-with-sail-boat-after-shipwreck-with-skull-black-sails-palm-trees-gold-coins-uninhabited-island_15709554.htm

Menu Sound Effects: https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116

Menu Music: https://assetstore.unity.com/packages/audio/music/bard-s-tales-peaceful-harp-music-pack-lite-lite-190602
