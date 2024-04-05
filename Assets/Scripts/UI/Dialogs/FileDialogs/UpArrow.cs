using DG.Tweening;

using NPT.Main;

using UnityEngine;

namespace NPT.UI.Dialogs.FileDialogs
{
    [RequireComponent(typeof(RectTransform))]
    public class UpArrow : Hideable
    {
        public RectTransform ScaleObject;

        public float w;

        public override void Show(float d)
        {
            RectTransform r = GetComponent<RectTransform>();
            base.Show(d);
            ScaleObject.DOSizeDelta(new(w - r.sizeDelta.x, ScaleObject.sizeDelta.y), d).SetEase(Ease.OutCubic);
        }

        public override void Fade(float d)
        {
            RectTransform r = GetComponent<RectTransform>();
            base.Fade(d);
            ScaleObject.DOSizeDelta(new(w, ScaleObject.sizeDelta.y), d).SetEase(Ease.OutCubic);
        }
    }
}
