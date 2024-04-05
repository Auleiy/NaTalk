using System.IO;

using TMPro;

using Unity.VisualScripting;

using UnityEngine;

namespace NPT.UI.Dialogs.FileDialogs
{
    public class FileSelection : MonoBehaviour
    {
        public string FileName;
        public Color ExtensionColor;
        public TMP_Text Text;
        public FileType Type;

        public FileContainer Container;

        public enum FileType
        {
            File,
            Directory
        }

        public void ReadFile()
        {
            if (FileName == "..")
            {
                Text.text = "<color=#80D4FF>(上级文件夹)</color>";
                return;
            }

            string name = Path.GetFileNameWithoutExtension(FileName), ext = Path.GetExtension(FileName);
            Text.text = $"{name}<color=#{ExtensionColor.ToHexString()}>{ext}</color>";
        }

        public void OnClick()
        {
            Container.ChangeSelection(Container.IndexOf(this));
        }
    }
}
