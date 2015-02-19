using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerCollectCoin : IOutboundPacket
    {
        private int goldCoins;
        private int blueCoins;
        private IntVector position;

        public int GoldCoins
        {
            get { return this.goldCoins; }
        }

        public int BlueCoins
        {
            get { return this.blueCoins; }
        }

        public IntVector Position
        {
            get { return this.position; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerCollectCoin(int goldCoins, int blueCoins, IntVector position)
        {
            this.goldCoins = goldCoins;
            this.blueCoins = blueCoins;
            this.position = position;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "c"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.goldCoins);
            message.Add(this.blueCoins);
            message.Add(this.position.X); message.Add(this.position.Y);
        }
    }
}