namespace MessageLib.Packets.In
{
    [PacketInfo("w")]
    public class PacketPlayerReceiveWootup : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}