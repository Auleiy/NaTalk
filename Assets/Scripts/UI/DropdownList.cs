using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace NPT.UI
{
    public class DropdownList : MonoBehaviour
    {
        public GameObject Template;
        public float Duration;
        public RectTransform Content;
        [HideInInspector] public readonly List<DropdownItem> Items = new();
        public float MaxHeight;

        public void UpdateScale()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                RectTransform rc = Items[i].GetComponent<RectTransform>();
                rc.anchoredPosition = new(rc.anchoredPosition.x, -rc.sizeDelta.y * i);
            }
            RectTransform ril = Items.Last().GetComponent<RectTransform>(), r = GetComponent<RectTransform>();
            float height = -ril.anchoredPosition.y + ril.sizeDelta.y;
            Content.sizeDelta = new(Content.sizeDelta.x, height);
            r.sizeDelta = new(Content.sizeDelta.x, Mathf.Min(MaxHeight, height));
        }

        private int Size = 0;
        public void Add(string text)
        {
            GameObject o = Instantiate(Template, Content);
            DropdownItem item = o.GetComponent<DropdownItem>();
            item.Value = text;
            item.Index = Size;
            o.SetActive(true);
            item.Awake();
            Items.Add(item);
            Size++;
        }
    }

}
