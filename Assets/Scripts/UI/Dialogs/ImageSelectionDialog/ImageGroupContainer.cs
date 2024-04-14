using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace NPT.UI.Dialogs.ImageSelectionDialog
{
    public class ImageGroupContainer : MonoBehaviour
    {
        public List<ImageSelectionGroup> Groups;
        public GameObject Template;

        private void Update()
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                RectTransform rect = Groups[i].GetComponent<RectTransform>();
                if (i == 0)
                    rect.anchoredPosition = new(rect.anchoredPosition.x, -16);
                else
                {
                    RectTransform lr = Groups[i - 1].GetComponent<RectTransform>();
                    rect.anchoredPosition = new(rect.anchoredPosition.x, lr.anchoredPosition.y - lr.sizeDelta.y - 16);
                }
            }
            RectTransform ts = GetComponent<RectTransform>();
            if (Groups.Count != 0)
            {
                RectTransform tll = Groups.Last().GetComponent<RectTransform>();
                ts.sizeDelta = new(ts.sizeDelta.x, -tll.anchoredPosition.y + tll.sizeDelta.y + 16);
            }
            else
                ts.sizeDelta = new(ts.sizeDelta.x, 0);
        }

        public GameObject Add(string type, string file)
        {
            GameObject go = Instantiate(Template, transform);
            ImageSelectionGroup sg = go.GetComponent<ImageSelectionGroup>();
            sg.Name = type;
            sg.File = file;
            go.SetActive(true);
            Groups.Add(sg);
            return go;
        }

        public ImageSelectionGroup this[int index]
        {
            get => Groups[index];
            set => Groups[index] = value;
        }
    }
}
