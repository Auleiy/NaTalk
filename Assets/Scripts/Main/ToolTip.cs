using NPT.MainPlayer;
using TMPro;
using UnityEngine;

namespace NPT.Main
{
    [RequireComponent(typeof(AutoSizer))]
    public class ToolTip : Hideable
    {
        public string Text { get { return text; } set { text = value; UpdateText(); } }
        private string text;
        public TMP_Text TextUI;

        private void UpdateText() => TextUI.text = text;

        /*
        private void UpdateScale()
        {
            TextUI.text = text;
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new(Mathf.Min(TextUI.preferredWidth, 640) + 16, 0);
            rect.sizeDelta = new(rect.sizeDelta.x, TextUI.preferredHeight + 8);
        }
        */

        // Hideable
        protected override float HideAlpha => 0;
        protected override bool SetActive => false;
    }
}
