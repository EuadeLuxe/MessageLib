using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerWorldPortalPlace : IOutboundPacket
    {
        private string messageType;

        private int layer;
        private IntVector position;
        private int blockID;
        private string worldID;

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

        public string WorldID
        {
            get { return this.worldID; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerWorldPortalPlace(string derot, int layer, IntVector position, int blockID, string worldID)
        {
            this.messageType = derot;
            this.layer = layer;
            this.position = position;
            this.blockID = blockID;
            this.worldID = worldID;
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
            message.Add(this.worldID);
        }
    }
}