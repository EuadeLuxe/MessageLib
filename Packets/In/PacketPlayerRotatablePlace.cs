using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("br")]
    public class PacketPlayerRotatablePlace : IInboundPacket
    {
        public IntVector Position;
        public int BlockID;
        public int Rotation;
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.Position = new IntVector(message.GetInt(0), message.GetInt(1));
            this.BlockID = message.GetInt(2);
            this.Rotation = message.GetInt(3);
            this.UserID = message.GetInt(4);
        }
    }
}