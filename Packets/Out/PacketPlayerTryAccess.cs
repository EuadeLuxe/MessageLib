namespace MessageLib.Packets.Out
{
    public class PacketPlayerTryAccess : IOutboundPacket
    {
        private string password;

        public string Password
        {
            get { return this.password; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerTryAccess(string password)
        {
            this.password = password;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "access"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.password);
        }
    }
}