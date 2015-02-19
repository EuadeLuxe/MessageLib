namespace MessageLib.Packets.In
{
    [PacketInfo("lostaccess")]
    public class PacketPlayerAccessLost : IInboundPacket
    {

        public void Read(PlayerIOClient.Message message)
        {
        }
    }
}