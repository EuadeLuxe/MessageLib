using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerNoteblockPlace : IOutboundPacket
    {
        private string messageType;

        private int layer;
        private IntVector position;
        private int blockID;
        private int noteOffset;

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

        public int NoteOffset
        {
            get { return this.noteOffset; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerNoteblockPlace(string derot, int layer, IntVector position, int blockID, int noteOffset)
        {
            this.messageType = derot;
            this.layer = layer;
            this.position = position;
            this.blockID = blockID;
            this.noteOffset = noteOffset;
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
            message.Add(this.noteOffset);
        }
    }
}