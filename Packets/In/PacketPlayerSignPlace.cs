using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("ts")]
    public class PacketPlayerSignPlace : IInboundPacket
    {
        private IntVector Position;
        private int BlockID;
        private string Text;
        private int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.Position = new IntVector(message.GetInt(0), message.GetInt(1));
            this.BlockID = message.GetInt(2);
            this.Text = message.GetString(3);
            this.UserID = message.GetInt(4);
        }
    }
}
