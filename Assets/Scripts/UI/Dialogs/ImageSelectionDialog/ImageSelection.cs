using NPT.Main;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.UI.Dialogs.ImageSelectionDialog
{
    [RequireComponent(typeof(HoverTooltip))]
    public class ImageSelection : MonoBehaviour
    {
        public Image ImageUI;
        public string Name;
        public Sprite Image;

        public ImageSelectionGroup Group;

        public void Update()
        {
            HoverTooltip tt = GetComponent<HoverTooltip>();
            tt.Text = $"{Group.File}.{Group.Name}.{Name}";
            ImageUI.sprite = Image;
        }
    }
}
