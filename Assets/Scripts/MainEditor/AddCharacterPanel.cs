using NPT.Main;
using NPT.MainEditor;

using TMPro;

using UnityEngine;

using static NPT.Main.StaticValue;

public class AddCharacterPanel : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_Dropdown Portrait;

    public TMP_Dropdown Character;

    public AddPortraitDialog AddPortraitDialog;

    public void AddCharacterButtonOnClick()
    {
        if (string.IsNullOrEmpty(Name.text))
        {
            MainTipContainer.Create("��Ǽ�����", TipType.Error);
            return;
        }

        Characters.Add(new(Portrait.options[Portrait.value].image, Name.text));
        Character.options.Add(new(Name.text, Portrait.options[Portrait.value].image));
        Name.text = "";
        Character.value = Character.options.Count - 1;
        MainTipContainer.Create("�Ǽǳɹ�", TipType.Info);
    }

    public void PortraitDropdownOnValueChanged(int index)
    {
        /*
        DOTween.To(() => Name.text, (x) => Name.text = x, Portrait.options[index].text, .1f);

        if (index == 0)
        {
            if (Path.GetExtension(dlgResult.lpstrFile).Equals(".ppf"))
            {
                int l = Portrait.options.Count;
                BinaryReader br = new(new FileStream(dlgResult.lpstrFile, FileMode.Open, FileAccess.Read));
                byte[] head = br.ReadBytes(4);
                if (head == Encoding.ASCII.GetBytes("PPFB"))
                {
                    MainTipQueue.Create("�ļ�ͷ������NPT Portrait Profile�ļ���ͷ��", TipType.Error);
                    br.Close();
                    return;
                }
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string name = br.ReadString();
                    int dataLength = br.ReadInt32();
                    byte[] buffer = br.ReadBytes(dataLength);
                    Texture2D tex = new(0, 0);
                    tex.LoadImage(buffer);
                    Sprite spr = Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(.5f, .5f));
                    Portrait.options.Add(new(name, spr));
                }
                br.Close();
                Portrait.value = l;
                MainTipQueue.Create("��ӳɹ�", TipType.Info);
                return;
            }
            AddPortraitDialog.Show(.2f);
            AddPortraitDialog.File = dlgResult.lpstrFile;
        }
        */
    }
}
