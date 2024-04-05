using TMPro;

namespace NPT.UI
{
    public class LabelDropdown : Dropdown
    {
        public TMP_Text Text;

        public override void UpdateText()
        {
            if (Text != null)
                Text.text = Values[Index];
        }
    }
}