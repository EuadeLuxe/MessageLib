namespace MessageLib.Packets.In
{
    [PacketInfo("hide")]
    public class PacketDoorOpened : IInboundPacket
    {
        public string Type;

        public void Read(PlayerIOClient.Message message)
        {
            this.Type = message.GetString(0);
        }
    }
}