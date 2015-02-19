using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("wp")]
    public class PacketPlayerWorldPortalPlace : IInboundPacket
    {
        public IntVector Position;
        public int BlockID;
        public string Text;
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.Position = new IntVector(message.GetInt(0), message.GetInt(1));
            this.BlockID = message.GetInt(2);
            this.Text = message.GetString(3);
            this.UserID = message.GetInt(4);
        }
    }
}