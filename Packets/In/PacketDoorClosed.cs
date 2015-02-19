namespace MessageLib.Packets.In
{
    [PacketInfo("show")]
    public class PacketDoorClosed : IInboundPacket
    {
        public string Type;

        public void Read(PlayerIOClient.Message message)
        {
            this.Type = message.GetString(0);
        }
    }
}