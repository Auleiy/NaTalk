using NPT.Main;

using TMPro;

using UnityEngine;

namespace NPT.MainPlayer
{
    public abstract class Message : Hideable
    {
        public float Height { get; protected set; }
        public bool IsTemplate;
        public TMP_Text Text;
        public abstract MessageType MessageType { get; }
        public float TopMargin { get; protected set; }

        [HideInInspector]
        public float NoTweenTop;

        protected MessageContainer Container { get => GetComponentInParent<MessageContainer>(); }
        protected override bool SetActive => false;

        private void Start()
        {
            OnHide += RemoveInternal;
        }

        protected int GetId()
        {
            return Container.GetId(this);
        }

        protected virtual void RemoveInternal()
        {
            Destroy(gameObject);
        }

        public void Remove()
        {
            Container.Messages.Remove(this);
            Container.UpdateMessagePosition();
            Fade(.2f);
        }
    }

    public enum MessageType
    {
        Normal,
        Spliter,
        Aside,
        Option,
        BondScenario
    }
}
