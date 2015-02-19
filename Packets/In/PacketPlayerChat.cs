namespace MessageLib.Packets.In
{
    [PacketInfo("say")]
    public class PacketPlayerChat : IInboundPacket
    {
        public int UserID;
        public string Message;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.Message = message.GetString(1);
        }
    }
}