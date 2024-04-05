using System.Collections.Generic;

using NPT.Main;
using NPT.UI;

using TMPro;

using static NPT.Main.StaticValue;

namespace NPT.ResourceCreator
{
    public class EmotionTypeDropdown : InputFieldDropdown
    {
        public static List<string> TypesList = new();

        public override void OnEndEdit(string v)
        {
            if (string.IsNullOrWhiteSpace(v) && !string.IsNullOrEmpty(v))
            {
                MainTipContainer.Create("请输入文本", TipType.Error);
                GetComponent<TMP_InputField>().text = "";
                return;
            }

            if (string.IsNullOrEmpty(v))
                return;

            if (Values.Contains(v))
                ChangeSelection(Values.IndexOf(v));
            else
            {
                TypesList.Add(v);
                Values.Add(v);
                Index = Values.Count - 1;
            }
        }
        public new void Update()
        {
            Values.Clear();
            foreach (string t in TypesList)
                Values.Add(new(t));
        }
    }
}
