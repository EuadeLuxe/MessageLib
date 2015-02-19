using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerChat : IOutboundPacket
    {
        private string message;

        public string Message
        {
            get { return this.message; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerChat(string message)
        {
            this.message = message;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "say"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.message);
        }
    }
}