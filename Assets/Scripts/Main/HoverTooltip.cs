using UnityEngine;
using UnityEngine.EventSystems;

namespace NPT.Main
{
    public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerMoveHandler, IPointerExitHandler
    {
        [Multiline]
        public string Text;
        public ToolTip ToolTip;

        public void OnPointerEnter(PointerEventData eventData)
        {
            ToolTip.Text = Text;
            ToolTip.Show(.1f);
            StaticValue.Cursor.Fade(.1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ToolTip.Fade(.1f);
            StaticValue.Cursor.Show(.1f);
        }

        public void PointerForceExit()
        {
            OnPointerExit(null);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            RectTransform rect = ToolTip.GetComponent<RectTransform>();
            rect.anchoredPosition = eventData.position;
        }
    }
}
