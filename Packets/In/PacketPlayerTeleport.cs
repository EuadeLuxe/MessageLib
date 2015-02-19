using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("teleport")]
    public class PacketPlayerTeleport : IInboundPacket
    {
        public int UserID;
        public IntVector Position;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.Position = new IntVector(message.GetInt(1), message.GetInt(2));
        }
    }
}