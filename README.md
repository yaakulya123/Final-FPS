Video Recording: https://drive.google.com/file/d/1UXdHGc7q_uXHqP7yu5EFQoT97TZ1bIhS/view?usp=sharing

# Unity 3D First-Person Shooter Game Documentation

## Introduction
This document details our Unity 3D First-Person Shooter (FPS) game, designed for our class project. The game transitions from mountainous terrain to urban settings and finally to a highly secured facility, challenging players with dynamic combat mechanics and strategic navigation.

## Game Overview
Players start their journey in a mountainous area, proceed through urban environments, and infiltrate a secured facility. Gameplay involves navigating these diverse settings, managing combat encounters with intelligent enemies, and utilizing various weapons and tactical maneuvers.

## Gameplay Mechanics
- **Movement**: Players navigate using WASD keys.
- **Weapons**: Players are equipped with:
  - **Pistol**: A precision firearm with slow firing.
  - **Machine Gun**: A rapid-fire long-range weapon.
- **Reloading**: Automatic when ammo runs out.
- **Objectives**: Players must find keys to unlock new areas and complete objectives.

## Game Intstructions Images
![Alt text for the image](Player%20Controls.jpg)

![Alt text for the image](Objectives.jpg)

## Combat and Interaction
Enemies patrol predetermined paths but will chase the player upon detection. If players evade detection, enemies search the vicinity before resuming their patrol. The game integrates a health and shield system where the shield absorbs most damage until depleted, then health points are directly affected.

## User Interface (HUD)
The HUD is designed for clarity and constant feedback:
- **Health and Shield Status**: Prominently displayed at all times.
- **Ammunition Levels and Weapon Type**: Constantly visible on-screen.
- **Objective Indicator**: Directs players to their next target.

## Technical Challenges
Developing the game's AI presented challenges, especially in enemy behavior and interaction dynamics. Solutions included:
- **AI Behavior**: Refined using Unity's NavMesh for realistic patrols.
- **Dynamic Waypoint System**: Updates dynamically based on player actions.
- **Interactive Elements**: Implemented Unity’s raycasting for key interactions and door unlocking.

## Game Components and Features
Key game features:
- **Player Mechanics**: Detailed shooting and interaction capabilities.
- **Enemy AI**: Reacts intelligently to player actions, enhancing combat.
- **Strategic Elements**: Includes key collections and terminal interactions for area unlocking.

## Sound and Graphics
The game features comprehensive sound design to enhance immersion, including effects for shooting, jumping, and enemy alerts. Visuals are crafted using Unity's rendering techniques to support gameplay mechanics and provide a realistic environment.

## Endgame and Replayability
Upon depleting all health, players see a 'Game Over' screen with options to restart the level, encouraging gameplay refinement and strategy development.

## Conclusion
Developing this Unity 3D FPS game has been a comprehensive educational experience, emphasizing the practical application of game design theories. It enhanced our technical skills, problem-solving capabilities, and creative thinking.

## Key Points
- **Dynamic Environments**: Transition from natural landscapes to structured facilities.
- **Advanced Combat**: Features a sophisticated health and shield management system.
- **Interactive Gameplay**: Key collections and terminal interactions are central to progression.
- **Technical Achievements**: Overcame AI and interaction mechanic challenges using advanced Unity features.
- **Educational Value**: Provided hands-on experience in game development, boosting technical and creative skills.
