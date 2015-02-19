namespace MessageLib.Packets.In
{
    [PacketInfo("levelup")]
    public class PacketPlayerLevelup : IInboundPacket
    {
        public int UserID;
        public int Level;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.Level = message.GetInt(1);
        }
    }
}