namespace MessageLib.Packets.In
{
    [PacketInfo("mod")]
    public class PacketPlayerToggleMod : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}