# Falling Leaf

This is a game made with Unity3D for Unity Hyper Casual Hackathon (26.10.2019 - 27.10.2019) organized by @SmartProjectGMBH. Whole project was created from scratch in two days by Oops Lab and took 3rd place from 12. Here is its a little bit refactored version.

#### Oops Lab Team
In Oops Lab team were 2 members:
- @IDmikael - idea, designs, code, animations, visual effects.
- @Cmeerik - idea, illustrations.

### Idea
As our chosen mechanics was RisingUp/Falling and season was autumn, we decided to create a game about leaf which falls from the tree. 

Player has to control leaf falling, using swipes and avoid different barriers, such as tree branches, beatles, rain drops, which appear on the way down.

Also game has 3 weather states: Evening, Cloudy (Wind) and Rain. These states are changing randomly through game process and each has its own properties. For example at the Cloudy state appears a wind which moves leaf in the breeze direction.

### Developing process & tools
-  Main game mechanics I made with C# code.
-  For many game effects (like leafs fall on background, rain or drop splash) I used Unity Particle System
-  Start leaf animation, background transitions, leaf swing, etc. was made with default Unity Animation Player.
-  For clouds parallax effect was used "Free Parallax" plugin from Unity Asset Store: https://assetstore.unity.com/packages/tools/particles-effects/free-parallax-for-unity-2d-29422
-  Also for better sound on Android devices was used "Android Native Audio" plugin: https://assetstore.unity.com/packages/tools/audio/android-native-audio-35295

## Screenshots
- Main Screen
![Main Screen](https://github.com/IDmikael/FallingLeaf/blob/master/Screenshots/photo5384536358409841879.jpg "Main Screen")
- Rain weather state
![Rain weather state](https://github.com/IDmikael/FallingLeaf/blob/master/Screenshots/1.jpg)
- Wind weather state
![Wind weather state](https://github.com/IDmikael/FallingLeaf/blob/master/Screenshots/photo5384352538104540234.jpg)
- Evening weather state
![Evening weather state](https://github.com/IDmikael/FallingLeaf/blob/master/Screenshots/photo5384536358409841878.jpg)

### You can find working apk in Build directory 
