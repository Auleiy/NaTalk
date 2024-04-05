using UnityEngine;

namespace NPT.MainPlayer
{
    public class Aside : Message
    {
        public string TextValue;
        public override MessageType MessageType => MessageType.Aside;

        public void Start()
        {
            Text.text = TextValue;
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new(rect.sizeDelta.x, Text.preferredHeight);
            Height = rect.sizeDelta.y;
            TopMargin = 8;
        }
    }
}
