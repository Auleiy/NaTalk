using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.UI.Dialogs.ImageSelectionDialog
{
    public class ImageSelectButton : MonoBehaviour
    {
        public ImageSelectDialog Dialog;
        public Sprite Image;
        public string Text;

        public Image ImageUI;
        public TMP_Text TextUI;

        public void ChangeContent()
        {
            ImageUI.sprite = Image;
            TextUI.text = Text;
        }

        public void OnClick()
        {
            Dialog.SelectButton = this;
            Dialog.ShowDialog();
        }
    }
}
