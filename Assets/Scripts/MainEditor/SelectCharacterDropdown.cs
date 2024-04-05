using NPT.MainPlayer;

using TMPro;

using UnityEngine;

namespace NPT.MainEditor
{
    public class SelectCharacterDropdown : MonoBehaviour
    {
        public ConfirmDialog confirmDialog;
        public MessageContainer container;

        private void Start()
        {
            dropdown = GetComponent<TMP_Dropdown>();
        }

        public void RemoveSelection(SelectCharacterDropdownItemRemoveButton btn)
        {
            confirmDialog.ShowDialog("ɾ�������ɫ��������˽�ɫ��ص���Ϣ������ɾ����", () =>
            {
                for (int i = 0; i < dropdown.options.Count; i++)
                {
                    TMP_Dropdown.OptionData option = dropdown.options[i];
                    if (btn.Icon.sprite == option.image && btn.Text.text.Equals(option.text))
                    {
                        dropdown.options.Remove(option);
                        Destroy(btn.Item);
                        dropdown.value = -1;
                        dropdown.Hide();
                        foreach (NormalMessage m in container.GetMessageByCharacterId(i))
                            m.Remove();
                        return;
                    }
                }
            });
        }

        private TMP_Dropdown dropdown;

        public int GetId(SelectCharacterDropdownItemRemoveButton btn)
        {
            for (int i = 0; i < dropdown.options.Count; ++i)
                if (btn.Icon.sprite == dropdown.options[i].image && btn.Text.text.Equals(dropdown.options[i].text))
                    return i;
            return -1;
        }
    }
}
