# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Delivery Driver is a Unity 2D game project built with Unity 6000.2.8f1. The project uses the Universal Render Pipeline (URP) for 2D rendering and includes Unity's Input System for handling player input.

## Development Environment

**Unity Version:** 6000.2.8f1 (6000.2.8f1 c9992ac36c34)

**Required Packages:**
- Universal Render Pipeline (URP) 17.2.0
- Input System 1.14.2
- 2D Animation, Sprite, Tilemap packages
- Visual Scripting 1.9.7

## Project Structure

- `Assets/` - Main project assets
  - `Scenes/` - Unity scene files
  - `Driver.cs` - Main driver script component
  - `Settings/` - URP and project settings
  - `InputSystem_Actions.inputactions` - Input System action mappings
- `ProjectSettings/` - Unity project configuration files
- `Packages/` - Package dependencies (managed by Unity Package Manager)
- `Library/` - Unity-generated cache files (not version controlled)
- `GeneratedAssets/` - Auto-generated assets (appears to be from AI/ML features)

## Working with Unity Projects

Since this is a Unity project, all development must be done through the Unity Editor. There are no traditional build commands from the command line.

**Opening the Project:**
- Open Unity Hub
- Add this project directory
- Open with Unity 6000.2.8f1

**Building the Project:**
- In Unity Editor: File → Build Settings → Build
- For quick testing: Play button in Unity Editor

**Testing:**
- Press Play button in Unity Editor to enter Play Mode
- Unity Test Framework is available (package version 1.6.0)

## Code Architecture

This is an early-stage Unity 2D game project. The main game logic is implemented through MonoBehaviour components attached to GameObjects in the scene.

**Current Scripts:**
- `Driver.cs` - Basic MonoBehaviour template with Start() and Update() methods (Assets/Driver.cs:3)

**Unity Patterns:**
- MonoBehaviour lifecycle methods (Start, Update, etc.)
- Component-based architecture
- Scene-based game organization
- Input System for handling player input (modern event-based input handling)

## Key Unity Concepts

When working with this project, understand these Unity-specific patterns:

- **MonoBehaviour**: Base class for Unity scripts attached to GameObjects
- **Start()**: Called once when the script instance is enabled
- **Update()**: Called every frame for game logic
- **GameObject/Component Pattern**: Objects in scenes have components attached for functionality
- **Input System**: Modern input handling using Action Assets (InputSystem_Actions.inputactions)

## Package Management

Dependencies are managed through Unity Package Manager. The manifest file is at `Packages/manifest.json`. Unity automatically resolves and downloads packages when the project is opened.

To add new packages, use the Unity Editor's Package Manager window (Window → Package Manager).

## Rendering

The project uses Universal Render Pipeline (URP) for 2D rendering:
- URP settings: `Assets/UniversalRenderPipelineGlobalSettings.asset`
- Default volume profile: `Assets/DefaultVolumeProfile.asset`
- Renderer configured for 2D optimization

## Input System

The project uses Unity's new Input System (not the legacy Input Manager):
- Input actions are defined in `Assets/InputSystem_Actions.inputactions`
- Scripts should reference InputAction or use PlayerInput component
- Input events are handled through C# events/callbacks

## AI/ML Integration

The project includes Unity AI packages (Unity.ai.assistant, Unity.ai.generators, Unity.ai.inference version 2.3.0), suggesting integration with Unity's Muse or similar AI tools. The `GeneratedAssets/` folder contains AI-generated content.
