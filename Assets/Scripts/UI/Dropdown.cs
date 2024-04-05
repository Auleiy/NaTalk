using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using static NPT.Main.StaticValue;

namespace NPT.UI
{
    public abstract class Dropdown : Selectable, IPointerClickHandler
    {
        public RectTransform Template;
        public List<string> Values = new();
        public int Index;

        protected bool Opened = false;
        protected DropdownList List;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Opened)
                Close();
            else
                Open();
        }

        public virtual void Open()
        {
            Opened = true;
            GameObject o = Instantiate(Template.gameObject, transform);
            List = o.GetComponent<DropdownList>();
            o.SetActive(true);
            o.GetComponent<Graphic>().CrossFadeAlpha(0, 0, true);
            o.GetComponent<Graphic>().CrossFadeAlpha(1, colors.fadeDuration, true);
            foreach (string v in Values)
                List.Add(v);
            List.UpdateScale();
            List.Items[Index].Select();
        }

        public virtual void Close()
        {
            Opened = false;
            List.GetComponent<Graphic>().CrossFadeAlpha(0, colors.fadeDuration, true);
            StartCoroutine(DelayInvoke(() => Destroy(List.gameObject), colors.fadeDuration));
        }

        public virtual void ChangeSelection(int index)
        {
            Index = index;
            UpdateText();
        }

        public virtual void Update()
        {
            UpdateText();
        }

        public abstract void UpdateText();
    }
}