namespace MessageLib.Packets.Out
{
    public class PacketPlayerFace : IOutboundPacket
    {
        private string messageType;
        private int faceID;

        public int FaceID
        {
            get { return this.faceID; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerFace(string derot, int faceID)
        {
            this.messageType = derot + 'f';
            this.faceID = faceID;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return this.messageType; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.faceID);
        }
    }
}