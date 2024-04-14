using UnityEngine;

namespace NPT.Main.Types
{
    public class Dialog : Hideable
    {
        protected override float HideAlpha => 0;

        private new void Show(float d)
        {
            base.Show(d);
            GetComponent<CanvasGroup>().interactable = true;
        }

        private new void Fade(float d)
        {
            base.Fade(d);
            GetComponent<CanvasGroup>().interactable = false;
        }

        public virtual void ShowDialog() => Show(.2f);
        public virtual void OKPress() => Close();
        public virtual void Close() => Fade(.2f);
    }
}
