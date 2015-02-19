namespace MessageLib.Packets.Out
{
    public class PacketPlayerKey : IOutboundPacket
    {
        private string messageType;

        public enum KeyColor
        {
            RED,
            GREEN,
            BLUE,
            CYAN,
            MAGENTA,
            YELLOW
        }

        // ----------------------------------- Constructor
        public PacketPlayerKey(string derot, KeyColor keyColor)
        {
            this.messageType = derot + keyColor.GetCodeChar();
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return this.messageType; }
        }

        public void Write(PlayerIOClient.Message message)
        {
        }
    }

    public static class KeyColorExtensions
    {
        public static char GetCodeChar(this PacketPlayerKey.KeyColor keyColor)
        {
            switch (keyColor)
            {
                case PacketPlayerKey.KeyColor.RED: return 'r';
                case PacketPlayerKey.KeyColor.GREEN: return 'g';
                case PacketPlayerKey.KeyColor.BLUE: return 'b';
                case PacketPlayerKey.KeyColor.CYAN: return 'c';
                case PacketPlayerKey.KeyColor.MAGENTA: return 'm';
                case PacketPlayerKey.KeyColor.YELLOW: return 'y';
                    
                default: return ' ';
            }
        }
    }
}