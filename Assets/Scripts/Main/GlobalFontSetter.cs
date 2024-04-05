using TMPro;
using UnityEngine;

namespace NPT.Main
{
    [RequireComponent(typeof(TMP_Text))]
    public class GlobalFontSetter : MonoBehaviour
    {
        public bool UseCNFont = false;
        public TMP_FontAsset NormalFont, CNFont;
        public bool ForceUse = false;

        public void Update()
        {
            if (!ForceUse)
                UseCNFont = StaticValue.UseCNFont;
            if (UseCNFont)
                GetComponent<TMP_Text>().font = CNFont;
            else
                GetComponent<TMP_Text>().font = NormalFont;
        }

        private void OnValidate()
        {
            Update();
        }
    }
}