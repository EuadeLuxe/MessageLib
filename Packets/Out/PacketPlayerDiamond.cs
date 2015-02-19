using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerDiamond : IOutboundPacket
    {
        private IntVector position;

        public IntVector Position
        {
            get { return this.position; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerDiamond(IntVector position)
        {
            this.position = position;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "diamondtouch"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.position.X); message.Add(this.position.Y);
        }
    }
}