namespace MessageLib
{
    /// <summary>
    /// Interface for sendable packets. All packets which may be sent from the
    /// client to the server are declared as outbound packets. As the names of
    /// outbound packets sometimes depend on data received via inbound packets
    /// outbound packets do not possess a PacketInfo attribute. Outbound packets may
    /// be sent directly via a PlayerIOClient.Connection instance if the namespace
    /// MessageLib is imported via a using directive.
    /// </summary>
    public interface IOutboundPacket
    {
        /// <summary>
        /// The type of the message the outbound packet needs to be deserialized into.
        /// </summary>
        string MessageType
        {
            get;
        }

        /// <summary>
        /// Serializes the packet into the given message object.
        /// </summary>
        /// <param name="message">The message to write the serialized packet data into.</param>
        void Write(PlayerIOClient.Message message);
    }
}