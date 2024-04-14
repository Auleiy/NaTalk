using TMPro;

using UnityEngine;

namespace NPT.MainPlayer
{
    public class Aside : Message
    {
        public TMP_Text Text;

        public override MessageType MessageType => MessageType.Aside;

        public override void Initialize()
        {
            Text.text = TextValue;
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new(rect.sizeDelta.x, Text.preferredHeight);
            Height = rect.sizeDelta.y;
            TopMargin = 16;
        }
    }
}
