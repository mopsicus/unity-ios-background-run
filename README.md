# unity-ios-background-run
Little iOS plugin for Unity to work app in background

# note
You should to know, it will not works in unity main thread! I mean all that works in Update() and other MonoBehaviour will paused on minimized. So, you have to run some operation in another thread and it will not paused.
