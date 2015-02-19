namespace MessageLib.Packets.In
{
    [PacketInfo("k")]
    public class PacketPlayerCrown : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}
