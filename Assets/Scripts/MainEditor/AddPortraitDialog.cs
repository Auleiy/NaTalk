using NPT.Main;
using NPT.Main.Types;

using TMPro;

using UnityEngine;

using static NPT.Main.StaticValue;

namespace NPT.MainEditor
{
    // May be obsolute
    public class AddPortraitDialog : Dialog
    {
        public TMP_InputField Name;
        public TMP_Dropdown Portrait;

        [HideInInspector] public string File;

        public override void OKPress()
        {
            if (string.IsNullOrEmpty(Name.text))
            {
                MainTipContainer.Create("请起个名字", TipType.Error);
                return;
            }
            int l = Portrait.options.Count;
            Texture2D tex = new(0, 0);
            tex.LoadImage(System.IO.File.ReadAllBytes(File));
            tex.Apply();
            Sprite spr = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));
            Portrait.options.Add(new(Name.text, spr));
            Portrait.value = l;
            Name.text = "";
            MainTipContainer.Create("添加成功", TipType.Info);
            base.OKPress();
        }

        public override void Close()
        {
            Portrait.value = 1;
            base.Close();
        }
    }
}
