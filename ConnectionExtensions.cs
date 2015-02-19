using System;
using System.Collections.Concurrent;

namespace MessageLib
{
    public static class ConnectionExtensions
    {
        private static ConcurrentDictionary<Type, string> packetIDCache = new ConcurrentDictionary<Type, string>();

        /// <summary>
        /// An extension method allowing to send packets directly via Connection objects
        /// without having to worry about serialization.
        /// </summary>
        /// <param name="connection">the connection to send the packet to.</param>
        /// <param name="packet">The packet to send.</param>
        public static void Send(this PlayerIOClient.Connection connection, IOutboundPacket packet)
        {
            PlayerIOClient.Message message = PlayerIOClient.Message.Create(packet.MessageType);
            packet.Write(message);
            connection.Send(message);
        }

    }
}
