# KOE-Engine
(Knights of Eyres Engine)
Set of scripts for making an Open Worl RPG in the style of Chrono Trigger for Unity!
Used for the game I am working on - Knights of Eyres.

## Warning! This engine is for coders familiar with Unity
This engine is ALL code, there is NO user interface, beyond what Unity provides, and you will have to set up your own scene. As I will explain below, I am unable to upload the full project in it's current state, so in order to use this engine, you are going to have to do a bit of legwork to get it done. I'd reccomend you only use this engine if you have enough experience with Unity and C# that this does not worry you. Hopefully, I'll be able to make this easier to use in the future! Sorry about that! 

# Features:
 - Active Time Battles on the overworld
 - Text with scrolling dialogue
 - Item pickups
 - Dynamically loading area 'chunks'
 - Dynamic Music Transitions

# Planned Features:
- Dialogue Options (Sorry, they'll be along soon)
- Fully functioning start menu
- Crafting
- Skills used in the overworld
- Following party members
- Overworld Enemy AI

# Using the Engine
Unfortunately, I cannot upload the full Unity Project, as I have some copyrighted sprites and music there that I cannot redistribute. However, I will attempt to explain here how to use the scripts with your own engine, regardless! If enough interest is shown in this project, perhaps I will make an effort to upload a version of the project that uses royalty free sprites and music.

## Setting up your scene

### The Base Scene and Game Manager
Because of the open world nature of the engine, Scene setup is a bit weird, in that you're usually working with two scenes at once. This is because of the Game Manager Component, which must be present at all times while the game is running. This component should be attached to a gameobject within a 'Base Scene' that will always be present, while other scenes that gameplay takes place on will be loaded dynamically.
I reccomend that the same object that the Game Manager Component is set on also have either the rest of the applicable 'Manager' components attached, or have a child GameObject with them attached. HOWEVER, DO NOT ATTACH THE SCENE MANAGER COMPONENT TO THE GAME MANAGER, THEY ARE MEANT TO GO INTO THEIR OWN OBJECT IN GAMEPLAY SCENES
When working on any scene taking
