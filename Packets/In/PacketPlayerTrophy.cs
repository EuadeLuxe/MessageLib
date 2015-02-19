namespace MessageLib.Packets.In
{
    [PacketInfo("ks")]
    public class PacketPlayerTrophy : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}