namespace MessageLib.Packets.Out
{
    public class PacketInit : IOutboundPacket
    {
        // ----------------------------------- Constructor
        public PacketInit()
        {
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "init"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}