namespace MessageLib.Packets.Out
{
    public class PacketPlayerPotion : IOutboundPacket
    {
        private string messageType;
        private int potionID;

        public int PotionID
        {
            get { return this.potionID; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerPotion(string derot, int potionID)
        {
            this.messageType = derot + 'p';
            this.potionID = potionID;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return this.messageType; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.potionID);
        }
    }
}