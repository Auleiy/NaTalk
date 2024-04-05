using TMPro;

using UnityEngine;

namespace NPT.Main.StartPage
{
    [RequireComponent(typeof(TMP_Text))]
    public class VersionText : MonoBehaviour
    {
        private TMP_Text text;

        private void Start()
        {
            text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            text.text = $"{Application.productName} {StaticValue.Version} by {Application.companyName}\n" +
                $"Made with Unity {Application.unityVersion}";
        }
    }
}
