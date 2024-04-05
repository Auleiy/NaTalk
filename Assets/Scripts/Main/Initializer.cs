using UnityEngine;
using NPT.UI.Dialogs.FileDialogs;

namespace NPT.Main
{
    public class Initializer : MonoBehaviour
    {
        public ConfirmDialog ConfirmDialog;
        public OpenFileDialog FileDialog;
        public TipContainer TipQueue;
        public Cursor Cursor;

        private void Start()
        {
            StaticValue.ConfirmDialog = ConfirmDialog;
            StaticValue.OpenFileDialog = FileDialog;
            StaticValue.MainTipContainer = TipQueue;
            StaticValue.Cursor = Cursor;
        }
    }
}