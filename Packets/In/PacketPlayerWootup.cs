namespace MessageLib.Packets.In
{
    [PacketInfo("wu")]
    public class PacketPlayerWootup : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}