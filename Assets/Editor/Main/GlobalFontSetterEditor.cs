using System.Linq;

using NPT.Main;

using TMPro;

using UnityEditor;

using UnityEngine;

using static NPT.Main.StaticValue;

namespace NPT.Editor.Main
{
    [CustomEditor(typeof(GlobalFontSetter)), CanEditMultipleObjects]
    public class GlobalFontSetterEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            foreach (GlobalFontSetter o in targets.Cast<GlobalFontSetter>())
            {
                if (targets.Length > 1)
                    GUILayout.Label(o.gameObject.name);
                o.ForceUse = GUILayout.Toggle(o.ForceUse, "Force use target font");
                if (o.ForceUse)
                    o.UseCNFont = GUILayout.Toggle(o.UseCNFont, "Use CN font");
                GUILayout.Space(6);
                o.NormalFont = (TMP_FontAsset)EditorGUILayout.ObjectField("Default font", o.NormalFont, typeof(TMP_FontAsset), false);
                o.CNFont = (TMP_FontAsset)EditorGUILayout.ObjectField("CN font", o.CNFont, typeof(TMP_FontAsset), false);
                GUILayout.Space(8);
                if (GUILayout.Button("Set to default font"))
                    UseCNFont = false;
                if (GUILayout.Button("Set to CN font"))
                    UseCNFont = true;
                o.Update();
            }
        }
    }
}