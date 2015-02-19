namespace MessageLib.Packets.In
{
    [PacketInfo("allowpotions")]
    public class PacketAllowPotions : IInboundPacket
    {
        public bool AllowPotions;

        public void Read(PlayerIOClient.Message message)
        {
            this.AllowPotions = message.GetBoolean(0);
        }
    }
}