namespace MessageLib.Packets.In
{
    [PacketInfo("god")]
    public class PacketPlayerToggleGod : IInboundPacket
    {
        public int UserID;
        public bool IsGod;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.IsGod = message.GetBoolean(1);
        }
    }
}