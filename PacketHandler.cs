using System;

namespace MessageLib
{
    /// <summary>
    /// A simple attribute which must be used above all methods which should receive
    /// packets of their argument types. Any methods in a packet listener which are not
    /// marked as being packet handler will not be registered when using a packet dispatcher.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method)]
    public class PacketHandler : Attribute
    {
    }
}
