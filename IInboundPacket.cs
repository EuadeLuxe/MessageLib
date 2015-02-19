namespace MessageLib
{
    /// <summary>
    /// Interface for receivable packets. All packets provide read facilities in order
    /// to quickly construct packet objects and gain access to the data without deserializing
    /// the message manually first. Furthermore every packet declaration is preceded by a
    /// PacketInfo attribute defining its packet ID and must have a default constructor for
    /// instantiation via reflection.
    /// </summary>
    public interface IInboundPacket
    {
        /// <summary>
        /// Reads the packet given the specified message
        /// </summary>
        /// <param name="message">The message to deserialize the packet from.</param>
        void Read(PlayerIOClient.Message message);
    }
}
