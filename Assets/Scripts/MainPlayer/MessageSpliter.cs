namespace NPT.MainPlayer
{
    public class MessageSpliter : Message
    {
        public override MessageType MessageType => MessageType.Spliter;

        public void Start()
        {
            Text = null;
            Height = 0;
            TopMargin = 16;
        }
    }
}
