namespace MessageLib.Packets.Out
{
    public class PacketPlayerTrophy : IOutboundPacket
    {
        // ----------------------------------- Constructor
        public PacketPlayerTrophy()
        {
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "levelcomplete"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}