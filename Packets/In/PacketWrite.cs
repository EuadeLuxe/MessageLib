namespace MessageLib.Packets.In
{
    [PacketInfo("write")]
    public class PacketWrite : IInboundPacket
    {
        public string Title;
        public string Message;

        public void Read(PlayerIOClient.Message message)
        {
            this.Title = message.GetString(0);
            this.Message = message.GetString(1);
        }
    }
}
