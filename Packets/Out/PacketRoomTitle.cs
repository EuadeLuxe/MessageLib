namespace MessageLib.Packets.Out
{
    public class PacketRoomTitle : IOutboundPacket
    {
        private string title;

        public string Title
        {
            get { return this.Title; }
        }

        // ----------------------------------- Constructor
        public PacketRoomTitle(string title)
        {
            this.title = title;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "name"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.title);
        }
    }
}