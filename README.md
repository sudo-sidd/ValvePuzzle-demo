# Valve Puzzle

https://github.com/user-attachments/assets/e4e79d8b-ced0-4c8f-908c-910ba81d153f

A simple Unity puzzle where the player must find a valve handle and use it to fix a broken steam pipe.

## Overview

This project demonstrates a basic interaction system using interfaces. The player can pick up objects and use them on interactable objects in the world.

## Scripts

### Core System

- **IIntractable.cs** - Interface that all interactable objects must implement
- **Interactor.cs** - Attached to the player, handles raycasting and interaction logic

### Puzzle Objects

- **ValveHandle.cs** - A pickup item found on the floor. When the player interacts with it, it gets added to their inventory and the GameObject is destroyed.

- **SteamPipe.cs** - A broken pipe blocking the player's path. When the player uses a ValveHandle on it:
  - Stops the steam particle effect
  - Disables the blocking collider
  - Adds 60 noise to the NoiseMeter

### Utilities

- **NoiseMeter.cs** - Singleton that tracks noise levels in the world
- **PlayerController.cs** - First-person character controller with mouse look and WASD movement

## Setup

1. Attach `PlayerController` and `Interactor` to your player GameObject
2. Add a `CharacterController` component to the player
3. Place a `ValveHandle` prefab in the scene (must have a collider on the Interactable layer)
4. Place a `SteamPipe` prefab with references to its ParticleSystem and blocking Collider
5. Add a `NoiseMeter` somewhere in the scene

## Controls

- **WASD** - Movement
- **Mouse** - Look around
- **E** - Interact / Pick up / Use item

## Requirements

- Unity 2021.3 or later
- Universal Render Pipeline (URP)
