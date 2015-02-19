namespace MessageLib.Packets.In
{
    [PacketInfo("info")]
    public class PacketMessageBox : IInboundPacket
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
