using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerCheckpoint : IOutboundPacket
    {
        private IntVector position;

        public IntVector Position
        {
            get { return this.position; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerCheckpoint(IntVector position)
        {
            this.position = position;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "checkpoint"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.position.X); message.Add(this.position.Y);
        }
    }
}