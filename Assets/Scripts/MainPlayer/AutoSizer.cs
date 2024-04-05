using TMPro;

using Unity.Mathematics;

using UnityEngine;

namespace NPT.MainPlayer
{
    public class AutoSizer : MonoBehaviour
    {
        public TMP_Text Target;
        public float MaxWidth = 1000;
        public bool Width, Height;
        public float2 Padding;

        public void Update()
        {
            if (Width)
                GetComponent<RectTransform>().sizeDelta = new(Mathf.Min(MaxWidth, Target.preferredWidth) + Padding.x, GetComponent<RectTransform>().sizeDelta.y);
            if (Height)
                GetComponent<RectTransform>().sizeDelta = new(GetComponent<RectTransform>().sizeDelta.x, Target.preferredHeight + Padding.y);
        }
    }
}
