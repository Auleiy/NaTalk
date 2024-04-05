using System;
using System.IO;
using System.Linq;

using UnityEditor;

using UnityEngine;

namespace NPT.Main.Types
{
    public class SceneNameAttribute : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            string[] scenes = EditorBuildSettings.scenes
                .Where(s => !string.IsNullOrEmpty(s.path))
                .Select(s => Path.GetFileNameWithoutExtension(s.path))
                .ToArray();

            int index = Mathf.Max(0, Array.IndexOf(scenes, property.stringValue));

            EditorGUI.BeginChangeCheck();
            index = EditorGUI.Popup(position, label.text, index, scenes);
            if (EditorGUI.EndChangeCheck())
                property.stringValue = scenes[index];
        }
    }
#endif
}
