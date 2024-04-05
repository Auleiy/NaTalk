using NPT.Main;

using UnityEngine;

namespace NPT.ResourceCreator
{
    public class EmotionSaver : MonoBehaviour
    {
        public Form Form;

        public void Save()
        {
            /*
            string oldDirectory = Directory.GetCurrentDirectory();
            if (!SaveFile("NPT Emotion Profile文件|*.epf", Application.dataPath, "另存为", "epf", (int)OFN.EXPLORER | (int)OFN.FILEMUSTEXIST | (int)OFN.PATHMUSTEXIST, out LPOPENFILENAME dlgResult))
            {
                MainTipQueue.Create("请保存为一个文件", TipType.Error);
                return;
            }
            BinaryWriter bw = new(new FileStream(dlgResult.lpstrFile, FileMode.OpenOrCreate, FileAccess.Write));
            bw.Write(Encoding.ASCII.GetBytes("EPFB"));
            bw.Write(TypesList.Count);
            foreach (string s in TypesList)
                bw.Write(s);
            bw.Write(Form.Lines.Count);
            foreach (EmotionFormLine e in Form.Lines.Cast<EmotionFormLine>())
            {
                bw.Write(e.Text);
                bw.Write(e.Type);
                byte[] b = e.Image.texture.EncodeToPNG();
                bw.Write(b.Length);
                bw.Write(b);
            }
            bw.Flush();
            bw.Close();
            Directory.SetCurrentDirectory(oldDirectory);
            MainTipQueue.Create("保存完成", TipType.Info);
            */
        }

        public void Load()
        {
            /*
            if (!OpenFile("NPT Emotion Profile文件|*.epf", Application.dataPath, "打开文件", "epf", (int)OFN.EXPLORER | (int)OFN.FILEMUSTEXIST | (int)OFN.PATHMUSTEXIST | (int)OFN.NOCHANGEDIR, out LPOPENFILENAME dlgResult))
            {
                MainTipQueue.Create("请选择文件", TipType.Error);
                return;
            }
            BinaryReader br = new(new FileStream(dlgResult.lpstrFile, FileMode.Open, FileAccess.Read));
            byte[] head = br.ReadBytes(4);
            if (head == Encoding.ASCII.GetBytes("EPFB"))
            {
                MainTipQueue.Create("文件头部不是NPT Emotion Profile文件的头部", TipType.Error);
                br.Close();
                return;
            }
            TypesList.Clear();
            foreach (FormLine fl in Form.Lines)
                Destroy(fl.gameObject);
            Form.Lines.Clear();
            int TypesCount = br.ReadInt32();
            for (int i = 0; i < TypesCount; i++)
            {
                string type = br.ReadString();
                TypesList.Add(type);
            }
            int EmotionsCount = br.ReadInt32();
            for (int i = 0; i < EmotionsCount;i++)
            {
                string name = br.ReadString();
                int typeIndex = br.ReadInt32();
                int dataLength = br.ReadInt32();
                byte[] buffer = br.ReadBytes(dataLength);
                Texture2D tex = new(0, 0);
                tex.LoadImage(buffer);
                Sprite spr = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));
                GameObject go = Form.Create();
                EmotionFormLine efl = go.GetComponent<EmotionFormLine>();
                efl.IsLoad = true;
                efl.Type = typeIndex;
                efl.Text = name;
                efl.Image = spr;
                efl.TypeUI.GetComponent<EmotionTypeDropdown>().Update();
                efl.TypeUI.ChangeSelection(efl.Type);
                efl.TextUI.text = efl.Text;
            }
            br.Close();
            MainTipQueue.Create("加载完成", TipType.Info);
            */
        }
    }
}
