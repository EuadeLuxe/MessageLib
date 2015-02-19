namespace MessageLib.Packets.In
{
    [PacketInfo("updatemeta")]
    public class PacketRoomMeta : IInboundPacket
    {
        public string Owner;
        public string Title;
        public int Plays;
        public int Woots;
        public int TotalWoots;

        public void Read(PlayerIOClient.Message message)
        {
            this.Owner = message.GetString(0);
            this.Title = message.GetString(1);
            this.Plays = message.GetInt(2);
            this.Woots = message.GetInt(3);
            this.TotalWoots = message.GetInt(4);
        }
    }
}