namespace MessageLib.Packets.Out
{
    public class PacketPlayerQuickchat : IOutboundPacket
    {
        private int messageID;

        public int MessageID
        {
            get { return this.messageID; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerQuickchat(int messageID)
        {
            this.messageID = messageID;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "autosay"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.messageID);
        }
    }
}