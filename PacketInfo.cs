using System;

namespace MessageLib
{
    /// <summary>
    /// Every packet declaration needs to have a packet info attribute
    /// which specifies the packet's id needed for deserializing it.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class)]
    public class PacketInfo : Attribute
    {
        /// <summary>
        /// The ID of the packet.
        /// </summary>
        public string ID;

        public PacketInfo(string id)
        {
            this.ID = id;
        }
    }
}
