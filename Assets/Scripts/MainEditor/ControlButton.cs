using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (Selectable o in GetComponentsInChildren<Selectable>())
            o.interactable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (Selectable o in GetComponentsInChildren<Selectable>())
            o.interactable = false;
    }
}
