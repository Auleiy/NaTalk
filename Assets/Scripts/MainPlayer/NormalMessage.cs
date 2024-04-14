using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static NPT.Main.StaticValue;

namespace NPT.MainPlayer
{
    public class NormalMessage : Message
    {
        public TMP_Text Text;

        public int CharacterId;
        public bool Direction;

        public RectTransform Portrait, Name, Arrow;
        public override MessageType MessageType => MessageType.Normal;

        public RectTransform MessageBox, ControlButtons;
        public float MessageBoxPadding = 8.66f;

        public GameObject Decoration;

        private bool Fold;

        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateContent()
        {
            Text.text = TextValue;
            MessageBox.sizeDelta = new(Mathf.Min(522, Text.preferredWidth + 24), 0);
            MessageBox.sizeDelta = new(MessageBox.sizeDelta.x, Text.preferredHeight + MessageBoxPadding);
            Height = MessageBox.sizeDelta.y;
            GetComponent<RectTransform>().sizeDelta = new(GetComponent<RectTransform>().sizeDelta.x, MessageBox.sizeDelta.y);

            if (!Container.IsLastSplit(GetId()))
            {
                Decoration.SetActive(false);
                TopMargin = 10;
                Fold = true;
            }
            else if (CharacterId != 0)
            {
                Decoration.SetActive(true);
                TopMargin = 32;
                Fold = false;
            }
            else
            {
                Decoration.SetActive(true);
                TopMargin = 16;
                Portrait.gameObject.SetActive(false);
                Name.gameObject.SetActive(false);
                Fold = false;
            }

            if (CharacterId != 0)
            {
                Portrait.GetComponent<Image>().sprite = Characters[CharacterId].Portrait;
                Name.GetComponent<TMP_Text>().text = Characters[CharacterId].Name;

                if (Direction)
                {
                    Portrait.anchorMin = new(1, 1);
                    Portrait.anchorMax = new(1, 1);
                    Portrait.pivot = new(1, 0);
                    Portrait.anchoredPosition = new(-20, -67.5842f);
                    Name.anchorMin = new(1, 1);
                    Name.anchorMax = new(1, 1);
                    Name.pivot = new(1, .5f);
                    Name.anchoredPosition = new(-132, 22);
                    Name.GetComponent<TMP_Text>().horizontalAlignment = HorizontalAlignmentOptions.Right;
                    Arrow.anchorMin = new(1, 1);
                    Arrow.anchorMax = new(1, 1);
                    Arrow.pivot = new(1, 0);
                    Arrow.anchoredPosition = new(-132, -16);
                    Arrow.rotation = Quaternion.Euler(0, 0, 180);
                    MessageBox.anchorMin = new(1, 1);
                    MessageBox.anchorMax = new(1, 1);
                    MessageBox.pivot = new(1, 1);
                    MessageBox.anchoredPosition = new(-132, 0);
                    Text.horizontalAlignment = HorizontalAlignmentOptions.Right;
                    MessageBox.GetComponent<Image>().color = Highlight;
                    if (!Fold)
                    {
                        Arrow.GetComponent<Image>().color = Highlight;
                        Name.GetComponent<TMP_Text>().color = HighlightText;
                    }
                }
                else
                {
                    Portrait.anchorMin = new(0, 1);
                    Portrait.anchorMax = new(0, 1);
                    Portrait.pivot = new(0, 0);
                    Portrait.anchoredPosition = new(20, -67.5842f);
                    Name.anchorMin = new(0, 1);
                    Name.anchorMax = new(0, 1);
                    Name.pivot = new(0, .5f);
                    Name.anchoredPosition = new(132, 22);
                    Name.GetComponent<TMP_Text>().horizontalAlignment = HorizontalAlignmentOptions.Left;
                    Arrow.anchorMin = new(0, 1);
                    Arrow.anchorMax = new(0, 1);
                    Arrow.pivot = new(1, 1);
                    Arrow.anchoredPosition = new(132, -16);
                    Arrow.rotation = Quaternion.Euler(0, 0, 0);
                    MessageBox.anchorMin = new(0, 1);
                    MessageBox.anchorMax = new(0, 1);
                    MessageBox.pivot = new(0, 1);
                    MessageBox.anchoredPosition = new(132, 0);
                    Text.horizontalAlignment = HorizontalAlignmentOptions.Left;
                    MessageBox.GetComponent<Image>().color = Normal;
                    if (!Fold)
                    {
                        Arrow.GetComponent<Image>().color = Normal;
                        Name.GetComponent<TMP_Text>().color = NormalText;
                    }
                }
            }
            else
            {
                if (Direction)
                {
                    Arrow.anchorMin = new(1, 1);
                    Arrow.anchorMax = new(1, 1);
                    Arrow.pivot = new(1, 0);
                    Arrow.anchoredPosition = new(-30, -16);
                    Arrow.rotation = Quaternion.Euler(0, 0, 180);
                    MessageBox.anchorMin = new(1, 1);
                    MessageBox.anchorMax = new(1, 1);
                    MessageBox.pivot = new(1, 1);
                    MessageBox.anchoredPosition = new(-30, 0);
                    MessageBox.GetComponent<Image>().color = Highlight;
                    if (!Fold)
                    {
                        Arrow.GetComponent<Image>().color = Highlight;
                        Name.GetComponent<TMP_Text>().color = HighlightText;
                    }
                }
                else
                {
                    Arrow.anchorMin = new(0, 1);
                    Arrow.anchorMax = new(0, 1);
                    Arrow.pivot = new(1, 1);
                    Arrow.anchoredPosition = new(30, -16);
                    Arrow.rotation = Quaternion.Euler(0, 0, 0);
                    MessageBox.anchorMin = new(0, 1);
                    MessageBox.anchorMax = new(0, 1);
                    MessageBox.pivot = new(0, 1);
                    MessageBox.anchoredPosition = new(30, 0);
                    MessageBox.GetComponent<Image>().color = Normal;
                    if (!Fold)
                    {
                        Arrow.GetComponent<Image>().color = Normal;
                        Name.GetComponent<TMP_Text>().color = NormalText;
                    }
                }
            }
        }
    }
}
