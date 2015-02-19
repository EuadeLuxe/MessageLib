namespace MessageLib.Packets.In
{
    [PacketInfo("upgrade")]
    public class PacketUpgrade : IInboundPacket
    {

        public void Read(PlayerIOClient.Message message)
        {
        }
    }
}