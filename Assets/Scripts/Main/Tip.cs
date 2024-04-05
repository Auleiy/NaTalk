using DG.Tweening;
using NPT.MainPlayer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static NPT.Main.StaticValue;

namespace NPT.Main
{
    public class Tip : MonoBehaviour
    {
        public TMP_Text TextGUI;
        public string Text;
        public TipType Type;
        public bool IsTemplate = true;

        public AudioClip Info, Warning, Error;

        [HideInInspector]
        public int TopIndex;

        private void Start()
        {
            TipContainer queue = GetComponentInParent<TipContainer>();
            TextGUI.text = Type switch
            {
                TipType.Info => "⊙",
                TipType.Warning => "⚠",
                TipType.Error => "⊗",
                _ => ""
            } + Text;

            GetComponent<Image>().color = Type switch
            {
                TipType.Info => Color.HSVToRGB(1f / 360 * 200, .5f, 1),
                TipType.Warning => Color.HSVToRGB(1f / 360 * 50, .5f, 1),
                TipType.Error => Color.HSVToRGB(0, .5f, 1),
                _ => Color.black
            };
            RectTransform rect = GetComponent<RectTransform>();
            GetComponent<AutoSizer>().Update();
            rect.anchoredPosition = new(rect.sizeDelta.x, rect.anchoredPosition.y);
            rect.DOAnchorPosX(0, .5f).SetEase(Ease.OutCubic);
            StartCoroutine(DelayInvoke(() => rect.DOAnchorPosX(rect.sizeDelta.x, .5f).SetEase(Ease.InCubic), 3f));
            StartCoroutine(DelayInvoke(() => queue.Destroy(this), 3.51f));
            GetComponent<AudioSource>().clip = Type switch
            {
                TipType.Info => Info,
                TipType.Warning => Warning,
                TipType.Error => Error,
                _ => null
            };
            GetComponent<AudioSource>().Play();
        }
    }
    public enum TipType
    {
        Info,
        Warning,
        Error
    }
}
