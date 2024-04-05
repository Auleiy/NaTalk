using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.MainEditor
{
    public class SelectCharacterDropdownItemRemoveButton : MonoBehaviour
    {
        public Image Icon;
        public TMP_Text Text;
        public GameObject Item;
        public SelectCharacterDropdown Dropdown;

        private void Update()
        {
            int id = Dropdown.GetId(this);
            if (id == 0 || id == 1)
                Destroy(gameObject);
        }
    }
}
