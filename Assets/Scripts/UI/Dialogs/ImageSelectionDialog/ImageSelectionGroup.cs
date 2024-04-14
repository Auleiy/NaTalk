using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace NPT.UI.Dialogs.ImageSelectionDialog
{
    public class ImageSelectionGroup : MonoBehaviour
    {
        public List<ImageSelection> Items;

        public GameObject ItemTemplate;

        public string Name, File;
        public TMP_Text NameUI;
        public RectTransform NameUIMask;

        private void Update()
        {
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new(rect.sizeDelta.x,
                Mathf.FloorToInt((GetColumnAndLine(Items.Count - 1).row + 1) * 72 + 24));

            for (int i = 0; i < Items.Count; i++)
            {
                RectTransform tr = Items[i].GetComponent<RectTransform>();
                tr.anchoredPosition = new(16 + (GetColumnAndLine(i).col * 72),
                    -16 - (GetColumnAndLine(i).row * 72));
            }

            NameUI.text = $"{File}.{Name}";
            NameUIMask.sizeDelta = new(NameUI.preferredWidth + 16, 25);
        }

        private (int col, int row) GetColumnAndLine(int index)
        {
            int row = Mathf.FloorToInt((float)index / 12);
            int col = index % 12;
            return (col, row);
        }

        public ImageSelection Add(string name, Sprite image)
        {
            GameObject go = Instantiate(ItemTemplate, transform);
            go.SetActive(true);
            ImageSelection sel = go.GetComponent<ImageSelection>();
            sel.Name = name;
            sel.Image = image;
            sel.Group = this;
            Items.Add(sel);
            sel.Update();
            return sel;
        }
    }
}
