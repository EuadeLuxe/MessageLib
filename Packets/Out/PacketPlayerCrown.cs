namespace MessageLib.Packets.Out
{
    public class PacketPlayerCrown : IOutboundPacket
    {
        private string messageType;

        // ----------------------------------- Constructor
        public PacketPlayerCrown(string derot)
        {
            this.messageType = derot + 'k';
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return this.messageType; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }
}