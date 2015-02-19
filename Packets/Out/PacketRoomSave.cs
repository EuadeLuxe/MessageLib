namespace MessageLib.Packets.Out
{
    public class PacketRoomSave : IOutboundPacket
    {
        // ----------------------------------- Constructor
        public PacketRoomSave()
        {
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "save"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}