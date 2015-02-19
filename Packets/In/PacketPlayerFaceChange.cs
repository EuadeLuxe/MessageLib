namespace MessageLib.Packets.In
{
    [PacketInfo("face")]
    public class PacketPlayerFaceChange : IInboundPacket
    {
        public int UserID;
        public int FaceID;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.FaceID = message.GetInt(1);
        }
    }
}