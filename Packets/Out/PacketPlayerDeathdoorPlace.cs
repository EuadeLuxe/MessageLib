using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerDeathdoorPlace : IOutboundPacket
    {
        private string messageType;

        private int layer;
        private IntVector position;
        private int blockID;
        private int deathCount;

        public int Layer
        {
            get { return this.layer; }
        }

        public IntVector Position
        {
            get { return this.position; }
        }

        public int BlockID
        {
            get { return this.blockID; }
        }

        public int DeathCount
        {
            get { return this.deathCount; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerDeathdoorPlace(string derot, int layer, IntVector position, int blockID, int deathCount)
        {
            this.messageType = derot;
            this.layer = layer;
            this.position = position;
            this.blockID = blockID;
            this.deathCount = deathCount;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return this.messageType; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.layer);
            message.Add(this.position.X); message.Add(this.position.Y);
            message.Add(this.blockID);
            message.Add(this.deathCount);
        }
    }
}