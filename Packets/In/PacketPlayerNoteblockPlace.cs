using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("bs")]
    public class PacketPlayerNoteblockPlace : IInboundPacket
    {
        public IntVector Position;
        public int BlockID;
        public int SoundID;
        public int UserID;

        public void Read(PlayerIOClient.Message message)
        {
            this.Position = new IntVector(message.GetInt(0), message.GetInt(1));
            this.BlockID = message.GetInt(2);
            this.SoundID = message.GetInt(3);
            this.UserID = message.GetInt(4);
        }
    }
}