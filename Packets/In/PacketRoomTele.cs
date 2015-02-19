using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("tele")]
    public class PacketRoomTele : IInboundPacket
    {
        // Whether or not the players got killed by a hazard; If false then the owner entered /reset
        public bool KilledByHazard;
        public UserContainer[] Users;

        public void Read(PlayerIOClient.Message message)
        {
            this.KilledByHazard = message.GetBoolean(0);

            uint userCount = (message.Count - 1) / 3;
            this.Users = new UserContainer[userCount];
            for (uint i = 0; i < userCount; ++i)
            {
                UserContainer user = new UserContainer();
                user.ID = message.GetInt(i * 3 + 0);
                user.SpawnPosition = new IntVector(message.GetInt( i * 3 + 1 ), message.GetInt( i * 3 + 2 ) );
                this.Users[i] = user;
            }
        }

        public struct UserContainer
        {
            public int ID;
            public IntVector SpawnPosition;
        }

    }
}