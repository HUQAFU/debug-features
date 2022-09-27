# debug-features
It's a system that allows enable/disable some of test features/gameObjects during playtesting or ab testing

You can check how it works in DemoScene

To set control of desired GameObject just add somewhere script DebugItemController and setup variables:
- debugItemId - id of debug feature (must be unique)
- defaultValue - default state of debug feature
- EnabledGameObjectsWithPriority/DisabledGameObjectsWithPriority - (links to gameobjects that you need to control with their enabling/disabling priorities)

![image](https://user-images.githubusercontent.com/17470634/192490880-ba2dd034-4c8c-4717-8713-08f375c87c16.png)

DebugItemController script can be placed on instantiating GameObject (see DemoScene)
