namespace MessageLib.Packets.In
{
    [PacketInfo("clear")]
    public class PacketRoomClear : IInboundPacket
    {
        public int RoomWidth;
        public int RoomHeight;
        public int BorderBlockID;
        public int WorkareaBlockID;

        public void Read(PlayerIOClient.Message message)
        {
            this.RoomWidth = message.GetInt(0);
            this.RoomHeight = message.GetInt(1);
            this.BorderBlockID = message.GetInt(2);
            this.WorkareaBlockID = message.GetInt(3);
        }
    }
}