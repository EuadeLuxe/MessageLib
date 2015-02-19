using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerPortalPlace : IOutboundPacket
    {
        private string messageType;

        private int layer;
        private IntVector position;
        private int blockID;
        private int rotation;
        private int portalID;
        private int targetID;

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

        public int Rotation
        {
            get { return this.rotation; }
        }

        public int PortalID
        {
            get { return this.portalID; }
        }

        public int TargetID
        {
            get { return this.targetID; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerPortalPlace(string derot, int layer, IntVector position, int blockID, int rotation, int portalID, int targetID)
        {
            this.messageType = derot;
            this.layer = layer;
            this.position = position;
            this.blockID = blockID;
            this.rotation = rotation;
            this.portalID = portalID;
            this.targetID = targetID;
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
            message.Add(this.rotation);
            message.Add(this.portalID);
            message.Add(this.targetID);
        }
    }
}