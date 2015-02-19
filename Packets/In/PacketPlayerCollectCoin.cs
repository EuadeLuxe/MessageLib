namespace MessageLib.Packets.In
{
    [PacketInfo("c")]
    public class PacketPlayerCollectCoin : IInboundPacket
    {
        public int UserID;
        public int GoldCoins;
        public int BlueCoins;

        public void Read(PlayerIOClient.Message message)
        {
            this.UserID = message.GetInt(0);
            this.GoldCoins = message.GetInt(1);
            this.BlueCoins = message.GetInt(2);
        }
    }
}