using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("b")]
    public class PacketPlayerBrickPlace : IInboundPacket
    {
        public int Layer;
        public IntVector Position;
        public int BlockID;
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.Layer = message.GetInt(0);
            this.Position = new IntVector(message.GetInt(1), message.GetInt(2));
            this.BlockID = message.GetInt(3);
            this.UserID = message.GetInt(4);
        }
    }
}