using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;

namespace NPT.Editor.Main
{
    public static class EditorTools
    {
        // =========
        // Auto Save
        // =========
        [MenuItem("Tools/Auto Save/On")]
        private static void AutoSaveOn()
        {
            EditorApplication.playModeStateChanged += AutoSave;
            Debug.Log("Enabled autosave.");
        }

        [MenuItem("Tools/Auto Save/Off")]
        private static void AutoSaveOff()
        {
            EditorApplication.playModeStateChanged -= AutoSave;
            Debug.Log("Disabled autosave.");
        }

        private static void AutoSave(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
                Debug.Log("Saved.");
            }
        }
    }
}
