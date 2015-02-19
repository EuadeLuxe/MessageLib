namespace MessageLib.Packets.Out
{
    public class PacketRoomClear : IOutboundPacket
    {
        // ----------------------------------- Constructor
        public PacketRoomClear()
        {
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "clear"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}