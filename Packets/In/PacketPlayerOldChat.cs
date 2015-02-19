namespace MessageLib.Packets.In
{
    [PacketInfo("say_old")]
    public class PacketPlayerOldChat : IInboundPacket
    {
        public string Username;
        public string Message;

        public void Read(PlayerIOClient.Message message)
        {
            this.Username = message.GetString(0);
            this.Message = message.GetString(1);
        }
    }
}