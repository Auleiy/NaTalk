using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.Main.StartPage
{
    public class LoadingPage : Hideable
    {
        public TMP_Text Progress;
        public Image ProgressBarValue;

        public AsyncOperation Operation = null;

        protected override float HideAlpha => 0;

        private void Update()
        {
            if (Operation != null)
            {
                Progress.text = (Operation.progress * 100).ToString("0.00") + "%";
                ProgressBarValue.fillAmount = Operation.progress;
            }
        }
    }
}
