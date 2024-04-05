using NPT.Main;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.ResourceCreator
{
    public class PortraitFormLine : FormLine
    {
        public string Text;
        public Sprite Portrait;

        public TMP_InputField TextUI;
        public Image PortraitUI;

        public void Update()
        {
            Text = TextUI.text;
            PortraitUI.sprite = Portrait;
        }

        public void ChangePortrait()
        {
            /*
            if (!OpenFile("PNG图片（宽高比101:114）|*.png", Application.dataPath, "打开图片", "png", (int)OFN.EXPLORER | (int)OFN.FILEMUSTEXIST | (int)OFN.PATHMUSTEXIST | (int)OFN.NOCHANGEDIR, out LPOPENFILENAME dlgResult))
            {
                MainTipQueue.Create("请打开一个文件。", TipType.Error);
                return;
            }
            Texture2D tex = new(0, 0);
            tex.LoadImage(File.ReadAllBytes(dlgResult.lpstrFile));
            Portrait = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));
            */
        }
    }
}
