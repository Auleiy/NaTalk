using TMPro;

namespace NPT.UI
{
    public class InputFieldDropdown : Dropdown
    {
        public TMP_InputField Text;

        public override void Update()
        {
            base.Update();
            UpdateText();
        }

        public override void UpdateText()
        {
            if (Text != null)
            {
                if (Index < 0 || Index >= Values.Count)
                    Text.text = string.Empty;
                else
                    Text.text = Values[Index];
            }
        }

        public virtual void OnEndEdit(string v)
        {
            if (Values.Contains(v))
                ChangeSelection(Values.IndexOf(v));
            else
                Values.Add(v);
        }
    }
}