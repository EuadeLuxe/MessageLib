using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("add")]
    public class PacketPlayerJoin : IInboundPacket
    {
        public int UserID;
        public string Username;
        public int FaceID;
        public DoubleVector Position;
        public bool IsGod;
        public bool IsMod;
        public bool IsGuardian;
        public bool HasChat;
        public int Coins;
        public bool IsFriend;
        public bool IsPurple;
        public int Level;
        public bool IsClubMember;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.Username = message.GetString(1);
            this.FaceID = message.GetInt(2);
            this.Position = new DoubleVector(message.GetInt(3), message.GetInt(4));
            this.IsGod = message.GetBoolean(5);
            this.IsMod = message.GetBoolean(6);
            this.IsGuardian = message.GetBoolean(7);
            this.HasChat = message.GetBoolean(8);
            this.Coins = message.GetInt(9);
            this.IsFriend = message.GetBoolean(10);
            this.IsPurple = message.GetBoolean(11);
            this.Level = message.GetInt(12);
            this.IsClubMember = message.GetBoolean(13);
        }
    }
}