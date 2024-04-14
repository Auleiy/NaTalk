using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using NPT.Main;
using NPT.Main.Types;

using TMPro;

using Unity.VisualScripting;

using static NPT.Main.StaticValue;

namespace NPT.UI.Dialogs.FileDialogs
{
    public class OpenFileDialog : Dialog
    {
        public string Title, OpenedDirectory = null;
        public string SelectedFile;

        public List<string> Files;
        public (string Display, string Filter)[] Filters;
        public int FilterIndex;

        public FileContainer Container;
        public TMP_Dropdown Disk, Filter;

        public TMP_Text TitleUI;
        public UpArrow UpArrow;

        public TMP_InputField DirectoryInputField;
        public TMP_InputField FileNameInputField;

        public OnFinishedSelect OnFinishSelect;

        public bool Initialized { get; protected set; }

        private List<string> directories;
        private List<string> fileNames;

        private Dictionary<string, string> openedDirectory = new();
        private bool refreshOnRestart;

        private string spl_drive;

        private string sender;

        public delegate void OnFinishedSelect(string path);

        public void Reinitialize(string title, string senderKey, (bool EnableOnRestart, string Directory) startupDir, int startupFilterIndex, params (string Display, string Filter)[] filters)
        {
            OnFinishSelect = EmptyMethod;
            gameObject.SetActive(true);
            foreach (FileSelection item in Container.Items)
                Destroy(item.gameObject);
            Container.Items.Clear();
            Disk.options.Clear();
            foreach (DriveInfo disk in DriveInfo.GetDrives())
                Disk.options.Add(new(disk.Name));
            Title = title;
            Filters = filters;
            FilterIndex = startupFilterIndex;
            ChangePath(startupDir.Directory);
            refreshOnRestart = startupDir.EnableOnRestart;
            sender = senderKey;
            if (refreshOnRestart && openedDirectory.ContainsKey(sender))
                openedDirectory.Remove(sender);
            if (openedDirectory.ContainsKey(sender))
                ChangePath(openedDirectory[sender]);
            spl_drive = Path.GetPathRoot(OpenedDirectory);
            foreach (TMP_Dropdown.OptionData data in Disk.options)
            {
                if (data.Equals(s: spl_drive))
                    Disk.value = Disk.options.IndexOf(data);
            }
            RefreshSelection();
            Filter.ClearOptions();
            foreach ((string Display, string Filter) s in filters)
                Filter.options.Add(new($"{s.Display} ({s.Filter})"));
            Select("");
            ChangeFilterByCode(0);
            Initialized = true;
        }

        private void EmptyMethod(string a) { }

        public void Select(string file)
        {
            SelectedFile = file;
            FileNameInputField.text = file;
        }

        public void ChangeFilter(int index)
        {
            FilterIndex = index;
            Select("");
            RefreshSelection();
        }

        public void ChangeFilterByCode(int index)
        {
            FilterIndex = index;
            Filter.value = index;
            Filter.RefreshShownValue();
            RefreshSelection();
        }

        public void ChangePath(string path)
        {
            if (!Path.GetPathRoot(path).Equals(path))
                isChangeDiskToChangeNotChildPath = true;
            Disk.value = Disk.options.IndexOf(Path.GetPathRoot(path));
            Disk.RefreshShownValue();
            OpenedDirectory = path;
            DirectoryInputField.text = OpenedDirectory;
            RefreshSelection();
            isChangeDiskToChangeNotChildPath = false;
        }

        public void ChangeDrive(int index)
        {
            OpenedDirectory = Disk.options[index].text;
            DirectoryInputField.text = OpenedDirectory;
            RefreshSelection();
        }

        private bool upArrowShowed = false;
        private bool isChangeDiskToChangeNotChildPath = false;

        private void RefreshSelection()
        {
            TitleUI.text = $"{Title} - {OpenedDirectory}";
            foreach (FileSelection item in Container.Items)
                Destroy(item.gameObject);
            Container.Items.Clear();
            fileNames = Directory.GetFiles(OpenedDirectory, Filters[FilterIndex].Filter).ToList();
            directories = Directory.GetDirectories(OpenedDirectory).ToList();
            foreach (string dir in directories)
                Container.Add(dir, FileSelection.FileType.Directory);
            foreach (string file in fileNames)
                Container.Add(file, FileSelection.FileType.File);
            DirectoryInputField.text = OpenedDirectory;
            if (!Directory.GetDirectoryRoot(OpenedDirectory).Equals(OpenedDirectory) && !upArrowShowed)
            {
                UpArrow.Show(.2f);
                upArrowShowed = true;
            }
            if (Directory.GetDirectoryRoot(OpenedDirectory).Equals(OpenedDirectory) && upArrowShowed && !isChangeDiskToChangeNotChildPath)
            {
                UpArrow.Fade(.2f);
                upArrowShowed = false;
            }
        }

        public override void Close()
        {
            if (openedDirectory.ContainsKey(sender))
                openedDirectory[sender] = OpenedDirectory;
            else
                openedDirectory.Add(sender, OpenedDirectory);
            base.Close();
        }

        public override void OKPress()
        {
            if (SelectedFile.IsNullOrEmpty())
            {
                MainTipContainer.Create("请选择文件", TipType.Error);
                return;
            }
            if (openedDirectory.ContainsKey(sender))
                openedDirectory[sender] = OpenedDirectory;
            else
                openedDirectory.Add(sender, OpenedDirectory);
            OnFinishSelect(SelectedFile);
            base.OKPress();
        }

        public override void ShowDialog()
        {
            if (!Initialized)
                throw new Exception("Dialog not initialized.");
            base.ShowDialog();
            Initialized = false;
        }

        public void ChangeFileViaInputField(string t)
        {
            string[] parentFiles = Directory.GetFiles(Path.GetDirectoryName(t), Filters[FilterIndex].Filter);
            string[] odFiles = Directory.GetFiles(OpenedDirectory, Filters[FilterIndex].Filter);

            if (parentFiles.Contains(t))
            {
                SelectedFile = t;
                if (!Path.GetDirectoryName(t).Equals(OpenedDirectory))
                    ChangePath(Path.GetDirectoryName(t));
            }
            else if (odFiles.Contains(Path.Combine(OpenedDirectory, t)))
            {
                string tr = Path.Combine(OpenedDirectory, t);
                FileNameInputField.text = tr;
                SelectedFile = tr;
                if (!Path.GetDirectoryName(tr).Equals(OpenedDirectory))
                    ChangePath(Path.GetDirectoryName(t));
            }
            else
            {
                MainTipContainer.Create("文件不存在", TipType.Error);
                FileNameInputField.text = SelectedFile;
            }
        }
    }
}
