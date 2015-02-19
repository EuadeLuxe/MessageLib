namespace MessageLib.Packets.Out
{
    public class PacketAllowPotions : IOutboundPacket
    {
        private bool allowPotions;

        public bool AllowPotions
        {
            get { return this.allowPotions; }
        }

        // ----------------------------------- Constructor
        public PacketAllowPotions(bool allowPotions)
        {
            this.allowPotions = allowPotions;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "allowpotions"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.allowPotions);
        }
    }
}