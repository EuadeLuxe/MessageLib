using System.Drawing;

namespace MessageLib.Packets.In
{
    [PacketInfo("backgroundColor")]
    public class PacketBackgroundColor : IInboundPacket
    {
        public Color BackgroundColor;

        public void Read(PlayerIOClient.Message message)
        {
            this.BackgroundColor = Color.FromArgb(message.GetInt(0));
        }
    }
}