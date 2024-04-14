using NPT.Main.Types;

namespace NPT.UI.Dialogs.ImageSelectionDialog
{
    public class ImageSelectDialog : Dialog
    {
        public ImageSelectButton SelectButton;

        public override void OKPress()
        {
            Close();
        }

        public void ButtonPress(ImageSelection item)
        {
            SelectButton.Image = item.Image;
            SelectButton.Text = $"{item.Group.File}.{item.Group.Name}.{item.Name}";
            SelectButton.ChangeContent();
            Close();
        }
    }
}
