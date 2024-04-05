using NPT.Main;
using NPT.UI;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.ResourceCreator
{
    public class EmotionFormLine : FormLine
    {
        public int Type;
        public string Text;
        public Sprite Image;
        public InputFieldDropdown TypeUI;
        public TMP_InputField TextUI;
        public Image ImageUI;
        [HideInInspector] public bool IsLoad = false;

        private void Start()
        {
            if (!IsLoad)
            {
                TypeUI.GetComponent<EmotionTypeDropdown>().Update();
                EmotionFormLine efl = (EmotionFormLine)GetComponentInParent<Form>().GetPrevious(this);
                if (efl == null)
                    return;
                TypeUI.ChangeSelection(efl.Type);
            }
        }

        private void Update()
        {
            Type = TypeUI.Index;
            Text = TextUI.text;
            ImageUI.sprite = Image;
        }

        public void ChangePortrait()
        {
            /*
            if (!OpenFile("PNG图片（宽高比1:1）|*.png", Application.dataPath, "打开图片", "png", (int)OFN.EXPLORER | (int)OFN.FILEMUSTEXIST | (int)OFN.PATHMUSTEXIST | (int)OFN.NOCHANGEDIR, out LPOPENFILENAME dlgResult))
            {
                MainTipQueue.Create("请打开一个文件。", TipType.Error);
                return;
            }
            Texture2D tex = new(0, 0);
            tex.LoadImage(File.ReadAllBytes(dlgResult.lpstrFile));
            Image = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));*/
        }
    }
}
