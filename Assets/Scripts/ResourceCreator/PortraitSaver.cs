using NPT.Main;

using UnityEngine;

namespace NTP.ResourceCreator
{
    public class PortraitSaver : MonoBehaviour
    {
        public Form Form;

        public void Save()
        {
            /*
            if (!SaveFile("NPT Portrait Profile文件|*.ppf", Application.dataPath, "另存为", "ppf", (int)OFN.EXPLORER | (int)OFN.PATHMUSTEXIST, out LPOPENFILENAME dlgResult))
            {
                MainTipQueue.Create("请保存为一个文件", TipType.Error);
                return;
            }
            BinaryWriter bw = new(new FileStream(dlgResult.lpstrFile, FileMode.OpenOrCreate, FileAccess.Write));
            bw.Write(Encoding.ASCII.GetBytes("PPFB"));
            bw.Write(Form.Lines.Count);
            foreach (PortraitFormLine fl in Form.Lines.Cast<PortraitFormLine>())
            {
                bw.Write(fl.Text);
                byte[] buf = fl.Portrait.texture.EncodeToPNG();
                bw.Write(buf.Length);
                bw.Write(buf);
            }
            bw.Flush();
            bw.Close();
            */
        }
        
        public void Load()
        {
            /*
            if (!OpenFile("NPT Portrait Profile文件|*.ppf", Application.dataPath, "另存为", "ppf", (int)OFN.EXPLORER | (int)OFN.FILEMUSTEXIST | (int)OFN.PATHMUSTEXIST | (int)OFN.NOCHANGEDIR, out LPOPENFILENAME dlgResult))
            {
                MainTipQueue.Create("请选择文件", TipType.Error);
                return;
            }
            BinaryReader br = new(new FileStream(dlgResult.lpstrFile, FileMode.Open, FileAccess.Read));
            byte[] head = br.ReadBytes(4);
            if (head == Encoding.ASCII.GetBytes("PPFB"))
            {
                MainTipQueue.Create("文件头部不是NPT Portrait Profile文件的头部", TipType.Error);
                br.Close();
                return;
            }
            foreach (FormLine fl in Form.Lines)
                Destroy(fl.gameObject);
            Form.Lines.Clear();
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                GameObject go = Form.Create();
                PortraitFormLine line = go.GetComponent<PortraitFormLine>();
                string name = br.ReadString();
                int dataLength = br.ReadInt32();
                byte[] buffer = br.ReadBytes(dataLength);
                Texture2D tex = new(0, 0);
                tex.LoadImage(buffer);
                Sprite spr = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));
                line.TextUI.text = name;
                line.Portrait = spr;
                line.Update();
            }
            br.Close();
            */
        }
    }
}
