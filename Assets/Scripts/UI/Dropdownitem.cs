using TMPro;

using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NPT.UI
{
    public class DropdownItem : Selectable, IPointerClickHandler
    {
        public int Index;
        public string Value;
        public TMP_Text UI;
        public Dropdown Parent;

        public new void Awake()
        {
            UI.text = Value;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Parent.ChangeSelection(Index);
            Parent.Close();
            interactable = false;
        }
    }
}