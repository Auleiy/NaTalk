using System.Collections.Generic;
using System.Linq;

using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NPT.MainPlayer
{
    public class MessageContainer : MonoBehaviour
    {
        public List<Message> Messages = new();
        public float Top = 30;

        public TMP_Dropdown Characters;
        public GameObject NormalMessageTemplate, SpliterTemplate, AsideTemplate;
        public Transform Container;

        public int GetId(Message m)
        {
            for (int i = 0; i < Messages.Count; i++)
                if (Messages[i] == m)
                    return i;
            return -1;
        }

        public bool IsLastSplit(int id)
        {
            if (id == 0)
                return true;
            Message m = Messages[id - 1], mn = Messages[id];
            if (m.MessageType == MessageType.Normal)
            {
                if (((NormalMessage)m).CharacterId != ((NormalMessage)mn).CharacterId ||
                    ((NormalMessage)m).Direction != ((NormalMessage)mn).Direction)
                    return true;
            }
            else
                return true;
            return false;
        }

        public Message Last()
        {
            return Messages.Last();
        }

        public void UpdateMessagePosition()
        {
            float height = Top;
            for (int i = 0; i < Messages.Count; ++i)
            {
                if (Messages[i] is NormalMessage n)
                    n.UpdateContent();
                RectTransform rect = Messages[i].GetComponent<RectTransform>();
                if (i == 0)
                {
                    rect.DOAnchorPos(new(0, -Top), .3f).SetEase(Ease.OutCubic);
                    Messages[i].NoTweenTop = -Top;
                    height += rect.sizeDelta.y;
                }
                else
                {
                    RectTransform rl = Messages[i - 1].GetComponent<RectTransform>();
                    rect.DOAnchorPos(new(0, Messages[i - 1].NoTweenTop - rl.sizeDelta.y - Messages[i].TopMargin), .3f).SetEase(Ease.OutCubic);
                    Messages[i].NoTweenTop = Messages[i - 1].NoTweenTop - rl.sizeDelta.y - Messages[i].TopMargin;
                    height += rect.sizeDelta.y + Messages[i].TopMargin;
                }
            }
            height += Top;
            GetComponent<RectTransform>().sizeDelta = new(GetComponent<RectTransform>().sizeDelta.x, Mathf.Max(height, Screen.height));
            
            print("Updated all message position.");
        }

        private void SetLastNormalMessageStartPosition(float x)
        {
            if (Messages.Count == 1)
                Messages[^1].GetComponent<RectTransform>().anchoredPosition = new(x, -Top);
            else
            {
                RectTransform rl = Messages[^2].GetComponent<RectTransform>();
                Messages[^1].GetComponent<RectTransform>().anchoredPosition = new(x, rl.anchoredPosition.y - rl.sizeDelta.y - Messages[^1].TopMargin);
            }
        }

        public Message CreateNormalMessage(string text, int characterId, bool direction)
        {
            if (characterId == 1)
            {
                GameObject go = Instantiate(AsideTemplate, Container);
                Aside m = go.GetComponent<Aside>();
                m.IsTemplate = false;
                m.TextValue = text;
                go.SetActive(true);
                Messages.Add(m);
                m.Start();
                UpdateMessagePosition();
                GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;
                return m;
            }
            else
            {
                GameObject go = Instantiate(NormalMessageTemplate, Container);
                NormalMessage m = go.GetComponent<NormalMessage>();
                m.IsTemplate = false;
                m.TextValue = text;
                m.CharacterId = characterId;
                m.Direction = direction;
                Messages.Add(m);
                go.SetActive(true);
                m.UpdateContent();
                if (direction)
                    SetLastNormalMessageStartPosition(898);
                else
                    SetLastNormalMessageStartPosition(-898);
                UpdateMessagePosition();
                GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;
                return m;
            }
        }

        public Message CreateSpliter()
        {
            GameObject go = Instantiate(SpliterTemplate, Container);
            MessageSpliter m = go.GetComponent<MessageSpliter>();
            m.IsTemplate = false;
            Messages.Add(m);
            go.SetActive(true);
            m.Start();
            UpdateMessagePosition();
            GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;
            return m;
        }

        public List<NormalMessage> GetMessageByCharacterId(int chId)
        {
            List<NormalMessage> r = new();
            foreach (Message m in Messages)
                if (m is NormalMessage i && i.CharacterId == chId)
                    r.Add(i);
            return r;
        }
    }
}
