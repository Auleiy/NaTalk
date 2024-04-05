using UnityEngine;

namespace NPT.Main
{
    public class Cursor : Hideable
    {
        private void Update()
        {
            StaticValue.Cursor = this;
            UnityEngine.Cursor.visible = false;
            GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }

        // Hideable
        protected override float HideAlpha => .2f;
        protected override bool SetActive => false;
    }
}
