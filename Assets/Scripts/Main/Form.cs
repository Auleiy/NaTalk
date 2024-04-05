using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace NPT.Main
{
    [RequireComponent(typeof(RectTransform))]
    public class Form : MonoBehaviour
    {
        public GameObject LineTemplate;
        public RectTransform AddButton, Parent;
        public List<FormLine> Lines;
        public float StartTop = 36;

        private void Update()
        {
            float h = LineTemplate.GetComponent<RectTransform>().sizeDelta.y;
            for (int i = 0; i < Lines.Count; i++)
                Lines[i].GetComponent<RectTransform>().anchoredPosition = new(0, -StartTop - i * h);
            GetComponent<RectTransform>().sizeDelta = new(GetComponent<RectTransform>().sizeDelta.x, Mathf.Max(960, StartTop + Lines.Count * h + 56));
            AddButton.anchoredPosition = new(0, -StartTop - Lines.Count * h);
        }

        public GameObject Create()
        {
            GameObject go = Instantiate(LineTemplate, Parent);
            Lines.Add(go.GetComponent<FormLine>());
            go.SetActive(true);
            Update();
            GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;
            return go;
        }

        public FormLine GetPrevious(FormLine l)
        {
            int ind = Lines.IndexOf(l);
            if (ind > 0 && ind < Lines.Count)
                return Lines[ind - 1];
            return null;
        }

        public void CreateByButton()
        {
            Create();
        }
    }
}

