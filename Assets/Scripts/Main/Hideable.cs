using UnityEngine;
using DG.Tweening;
using static NPT.Main.StaticValue;
using System;

namespace NPT.Main
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Hideable : MonoBehaviour
    {
        protected virtual float HideAlpha { get; }
        protected virtual bool SetActive { get => true; }
        protected Tween Tween;

        public Action OnHide = () => { }, OnShow = () => { };

        public virtual void Fade(float d)
        {
            Tween?.Kill();
            Tween = GetComponent<CanvasGroup>().DOFade(HideAlpha, d);
            StartCoroutine(DelayInvoke(() => { if (SetActive) gameObject.SetActive(false); OnHide(); }, d + .1f));
        }
        public virtual void Show(float d)
        {
            if (SetActive)
                gameObject.SetActive(true);
            OnShow();
            Tween?.Kill();
            Tween = GetComponent<CanvasGroup>().DOFade(1, d);
        }
    }
}