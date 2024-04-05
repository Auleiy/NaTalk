using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NPT.Main.StartPage
{
    public class StartPageButton : UIBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Image BottomBoder;
        public Color DownColor;
        public Button.ButtonClickedEvent OnClick;
        public TMP_Text TextUI;

        private Tween t = null;

        public void OnPointerEnter(PointerEventData eventData)
        {
            t?.Kill();
            t = BottomBoder.DOFillAmount(1, 0.2f).SetEase(Ease.OutSine);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            t?.Kill();
            t = BottomBoder.DOFillAmount(0, 0.2f).SetEase(Ease.InSine);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            BottomBoder.CrossFadeColor(DownColor, 0.1f, true, true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            BottomBoder.CrossFadeColor(Color.white, 0.1f, true, true);
            OnClick.Invoke();
        }
    }
}
