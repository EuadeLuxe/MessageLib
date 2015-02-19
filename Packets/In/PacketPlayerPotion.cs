namespace MessageLib.Packets.In
{
    [PacketInfo("p")]
    public class PacketPlayerPotion : IInboundPacket
    {
        public int UserID;
        public int PotionID;
        public bool Active;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.PotionID = message.GetInt(1);
            this.Active = message.GetBoolean(2);
        }
    }
}