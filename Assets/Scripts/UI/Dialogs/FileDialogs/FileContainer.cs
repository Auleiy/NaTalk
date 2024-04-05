using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace NPT.UI.Dialogs.FileDialogs
{
    public class FileContainer : MonoBehaviour
    {
        public List<FileSelection> Items;
        public GameObject Template;

        public OpenFileDialog Dialog;

        public void ChangeSelection(int value)
        {
            FileSelection fs = Items[value];
            if (fs.Type == FileSelection.FileType.File)
                Dialog.Select(fs.FileName);
            if (fs.Type == FileSelection.FileType.Directory)
                Dialog.ChangePath(fs.FileName);
        }

        public void ToParent()
        {
            Dialog.ChangePath(Directory.GetParent(Dialog.OpenedDirectory).FullName);
        }

        public int IndexOf(FileSelection sel) => Items.IndexOf(sel);

        public void UpdateContainer()
        {
            float top = 2;
            foreach (var item in Items)
            {
                RectTransform rect = item.GetComponent<RectTransform>();
                rect.anchoredPosition = new(rect.anchoredPosition.x, -top);
                top += rect.sizeDelta.y;
            }
            GetComponent<RectTransform>().sizeDelta = new(GetComponent<RectTransform>().sizeDelta.x, top + 2);
        }

        public FileSelection Add(string fileName, FileSelection.FileType type)
        {
            GameObject go = Instantiate(Template, transform);
            FileSelection fs = go.GetComponent<FileSelection>();
            fs.FileName = fileName;
            fs.Type = type;
            fs.Container = this;
            go.SetActive(true);
            fs.ReadFile();
            Items.Add(fs);
            UpdateContainer();
            return fs;
        }
    }

}
