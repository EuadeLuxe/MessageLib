using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerSwitchPlace : IOutboundPacket
    {
        private string messageType;

        private int layer;
        private IntVector position;
        private int blockID;
        private int switchID;

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

        public int SwitchID
        {
            get { return this.switchID; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerSwitchPlace(string derot, int layer, IntVector position, int blockID, int switchID)
        {
            this.messageType = derot;
            this.layer = layer;
            this.position = position;
            this.blockID = blockID;
            this.switchID = switchID;
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
            message.Add(this.switchID);
        }
    }
}