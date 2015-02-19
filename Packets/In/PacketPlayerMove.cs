using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("m")]
    public class PacketPlayerMove : IInboundPacket
    {
        public int UserID;
        public DoubleVector Position;
        public DoubleVector Speed;
        public IntVector Modifiers;
        public IntVector Axes;
        public int Coins;
        public bool IsPurple;
        public bool HasLevitation;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.Position = new DoubleVector(message.GetDouble(1), message.GetDouble(2));
            this.Speed = new DoubleVector(message.GetDouble(3), message.GetDouble(4));
            this.Modifiers = new IntVector(message.GetInt(5), message.GetInt(6));
            this.Axes = new IntVector(message.GetInt(7), message.GetInt(8));
            this.Coins = message.GetInt(9);
            this.IsPurple = message.GetBoolean(10);
            this.HasLevitation = message.GetBoolean(11);
        }
    }
}