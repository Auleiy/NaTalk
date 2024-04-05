using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using TMPro;

using NPT.Main.Types;
using NPT.UI.Dialogs.FileDialogs;

namespace NPT.Main
{
    public static class StaticValue
    {
        public static List<Character> Characters = new() { null, null };
        public static readonly Color Normal = new Color32(76, 91, 111, 255),
                                     NormalText = new Color32(63, 68, 74, 255),
                                     Highlight = new Color32(74, 138, 202, 255),
                                     HighlightText = new Color32(51, 96, 140, 255);
        public static TipContainer MainTipContainer;
        public static ConfirmDialog ConfirmDialog;
        public static OpenFileDialog OpenFileDialog;
        public static Cursor Cursor;

        public static string Version = "0.0.1a";
        public static bool UseCNFont;

        public static IEnumerator DelayInvoke(Action act, float delay)
        {
            yield return new WaitForSeconds(delay);
            act();
        }

        // Extensions

        public static bool Equals(this TMP_Dropdown.OptionData d, string s) => d.text.Equals(s);
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);
        public static int IndexOf(this List<TMP_Dropdown.OptionData> l, string s)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Equals(s: s))
                    return i;
            }
            return -1;
        }
    }
}
