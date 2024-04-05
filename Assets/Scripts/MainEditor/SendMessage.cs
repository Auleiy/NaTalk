using NPT.Main;
using NPT.MainPlayer;
using NPT.UI;

using TMPro;

using UnityEngine;

using static NPT.Main.StaticValue;

namespace NPT.MainEditor
{
    public class SendMessage : MonoBehaviour
    {
        public TMP_Dropdown Character;
        public TMP_InputField Message;
        public ArrowToggle Direction;
        public MessageContainer Container;

        public void Send()
        {
            if (string.IsNullOrEmpty(Message.text))
            {
                MainTipContainer.Create("请输入内容", TipType.Error);
                return;
            }
            if (Character.value == 1 && Container.Last().MessageType == MessageType.Spliter)
            {
                MainTipContainer.Create("旁白前一条消息不能是分割", TipType.Warning);
                return;
            }
            Container.CreateNormalMessage(Message.text, Character.value, Direction.Value);
            Message.text = string.Empty;
            MainTipContainer.Create("发送成功", TipType.Info);
        }

        public void SendSplit()
        {
            if (Container.Messages.Count != 0 && Container.Last().MessageType == MessageType.Spliter)
            {
                MainTipContainer.Create("你刚刚已经分割了一次", TipType.Warning);
                return;
            }
            if (Container.Last().MessageType != MessageType.Normal)
            {
                MainTipContainer.Create("分割的上一条信息必须是普通信息", TipType.Warning);
                return;
            }
            Container.CreateSpliter();
            MainTipContainer.Create("发送成功", TipType.Info);
        }
    }
}
