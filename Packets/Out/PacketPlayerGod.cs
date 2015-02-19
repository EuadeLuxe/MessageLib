namespace MessageLib.Packets.Out
{
    public class PacketPlayerGod : IOutboundPacket
    {
        private bool isGod;

        public bool IsGod
        {
            get { return this.isGod; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerGod(bool isGod)
        {
            this.isGod = isGod;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "god"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.isGod);
        }
    }
}