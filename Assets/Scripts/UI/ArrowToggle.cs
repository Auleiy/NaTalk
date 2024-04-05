using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NPT.UI
{
    public class ArrowToggle : Selectable, IPointerUpHandler
    {
        public Graphic ArrowA, ArrowB;
        public bool Value;
        public Color32 On = new(255, 255, 255, 255), Off = new(255, 255, 255, 127);
        public float FadeDuration = 0.1f;

        public Toggle.ToggleEvent onToggle;

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            FadeColor();
        }
#endif

        protected override void Start()
        {
            base.Start();
            FadeColor();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            Toggle();
        }

        public void Toggle()
        {
            Value = !Value;
            FadeColor();
            onToggle.Invoke(Value);
        }

        private void FadeColor()
        {
            if (Value)
            {
                ArrowA.CrossFadeColor(Off, FadeDuration, true, true);
                ArrowB.CrossFadeColor(On, FadeDuration, true, true);
            }
            else
            {
                ArrowA.CrossFadeColor(On, FadeDuration, true, true);
                ArrowB.CrossFadeColor(Off, FadeDuration, true, true);
            }
        }
    }
}
