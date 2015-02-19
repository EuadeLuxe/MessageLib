namespace MessageLib.Packets.In
{
    [PacketInfo("access")]
    public class PacketPlayerAccessAcquired : IInboundPacket
    {
        public void Read(PlayerIOClient.Message message)
        {
        }
    }
}