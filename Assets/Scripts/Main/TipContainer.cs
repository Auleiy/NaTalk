using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace NPT.Main
{
    public class TipContainer : MonoBehaviour
    {
        public List<Tip> Tips;
        public GameObject TipTemplate;
        public float Top = 6, Gap = 6;

        private void Update()
        {
            for (int i = 0; i < Tips.Count; ++i)
            {
                if (Tips[i] == null)
                    continue;
                Tip tip = Tips[i];
                RectTransform rect = tip.GetComponent<RectTransform>();

                if (i != tip.TopIndex)
                {
                    tip.TopIndex = i;
                    rect.DOAnchorPosY(-Top - Gap * i - GetTop(i), .2f).SetEase(Ease.InOutCubic);
                }
            }
        }

        public float GetTop(int index)
        {
            float h = 0;
            for (int i = 0; i < Mathf.Min(index, Tips.Count); ++i)
                if (Tips[i] != null)
                    h += Tips[i].GetComponent<RectTransform>().sizeDelta.y;
            return h;
        }

        public void Destroy(Tip obj)
        {
            if (Tips.Contains(obj))
                Tips.RemoveAt(Tips.IndexOf(obj));
            Destroy(obj.gameObject);
        }

        public int GetEmptySlot() => Tips.IndexOf(null);

        public GameObject Create(string text, TipType type)
        {
            TipContainer tq = GetComponentInParent<TipContainer>();
            GameObject go = Instantiate(TipTemplate, tq.transform);
            Tip t = go.GetComponent<Tip>();
            t.IsTemplate = false;
            t.Text = text;
            t.Type = type;
            go.SetActive(true);
            int le = tq.GetEmptySlot();
            if (le >= 0)
                tq.Tips[le] = t;
            else
                tq.Tips.Add(t);

            t.TopIndex = Tips.IndexOf(t);
            t.GetComponent<RectTransform>().anchoredPosition = new(t.GetComponent<RectTransform>().sizeDelta.x, -Top - Gap * t.TopIndex - GetTop(t.TopIndex));
            return go;
        }
    }
}
