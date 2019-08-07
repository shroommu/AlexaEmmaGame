using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

// ensure class initializer is called whenever scripts recompile
[InitializeOnLoadAttribute]
public static class PlayModeStateChangedExample
{
    // register an event handler when the class is initialized
    static PlayModeStateChangedExample()
    {
        EditorApplication.playModeStateChanged += LogPlayModeState;
    }

    private static void LogPlayModeState(PlayModeStateChange state)
	{
		//Debug.Log("marking scenes dirty");
		EditorSceneManager.MarkAllScenesDirty();
		//Debug.Log("saving scenes");
		EditorSceneManager.SaveOpenScenes();
		//Debug.Log("closing scenes");
		//EditorSceneManager.CloseScene(SceneManager.GetSceneByName("AlexaScene"), false);
	}
}