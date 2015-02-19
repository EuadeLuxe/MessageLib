namespace MessageLib.Packets.In
{
    [PacketInfo("left")]
    public class PacketPlayerLeave : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}