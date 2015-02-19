namespace MessageLib.Packets.Out
{
    public class PacketReady : IOutboundPacket
    {
        // ----------------------------------- Constructor
        public PacketReady()
        {
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "init2"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}