namespace NPT.MainPlayer
{
    public class MessageSpliter : Message
    {
        public override MessageType MessageType => MessageType.Spliter;

        public override void Initialize()
        {
            Height = 0;
            TopMargin = 16;
        }
    }
}
