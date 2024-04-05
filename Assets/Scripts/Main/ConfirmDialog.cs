using System;
using NPT.Main.Types;
using TMPro;

public class ConfirmDialog : Dialog
{
    public string Content;
    public Action Behaviour;
    public TMP_Text ContentUI;

    public override void ShowDialog() => throw new NotImplementedException();

    public void ShowDialog(string content, Action behaviour)
    {
        Content = content;
        Behaviour = behaviour;
        ContentUI.text = Content;
        base.ShowDialog();
    }

    public override void OKPress()
    {
        Behaviour();
        base.OKPress();
    }
}
