namespace MessageLib.Packets.In
{
    [PacketInfo("guardian")]
    public class PacketPlayerToggleGuardian : IInboundPacket
    {
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
        }
    }
}