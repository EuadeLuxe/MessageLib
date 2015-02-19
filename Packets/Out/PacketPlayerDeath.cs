namespace MessageLib.Packets.Out
{
    public class PacketPlayerDeath : IOutboundPacket
    {
        // ----------------------------------- Constructor
        public PacketPlayerDeath()
        {
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "death"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}