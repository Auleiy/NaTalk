using System.IO;
using System.Linq;
using System.Text;

using NPT.Main;

using UnityEngine;

using static NPT.Main.StaticValue;

namespace NPT.UI.Dialogs.ImageSelectionDialog
{
    public class ImageLoader : MonoBehaviour
    {
        public ImageGroupContainer GroupContainer;

        int pid = 0;
        public void Load()
        {
            OpenFileDialog.Reinitialize("打开图片信息", "sk_ImageLoader", (false, "C:\\Users\\Administrator"), 0,
                ("NPT 图片信息", "*.ipf"),
                ("PNG 图像", "*.png")
            );
            OpenFileDialog.OnFinishSelect += read;
            OpenFileDialog.ShowDialog();
            void read(string path)
            {
                BinaryReader br = new(new FileStream(path, FileMode.Open, FileAccess.Read));
                byte[] head = br.ReadBytes(4);
                if (!head.SequenceEqual(Encoding.ASCII.GetBytes("IPFB")))
                {
                    MainTipContainer.Create("文件头部不是NPT Image Profile文件的头部", TipType.Error);
                    br.Close();
                    return;
                }
                int typesCount = br.ReadInt32();
                for (int i = 0; i < typesCount; i++)
                {
                    string type = $"{br.ReadString()} ({Path.GetFileNameWithoutExtension(path)})";
                    GroupContainer.Add(type);
                }
                int imagesCount = br.ReadInt32();
                for (int i = 0; i < imagesCount; i++)
                {
                    string name = br.ReadString();
                    int typeIndex = br.ReadInt32() + pid;
                    int imageLength = br.ReadInt32();
                    byte[] image = br.ReadBytes(imageLength);
                    Texture2D tex = new(0, 0);
                    tex.LoadImage(image);
                    Sprite spr = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));
                    GroupContainer[typeIndex].Add(name, spr);
                }
                pid = GroupContainer.Groups.Count;
                br.Close();
                MainTipContainer.Create("加载完成", TipType.Info);
                return;
            }
        }
    }
}
