using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MessageLib
{
    /// <summary>
    /// A packet dispatcher may be used to dispatch packets easily to listeners
    /// which may be registered to the dispatcher.
    /// </summary>
    public class PacketDispatcher
    {

        private List<PlayerIOClient.Connection> connections = new List<PlayerIOClient.Connection>();
        private ConcurrentDictionary<Type, List<PacketHandlerMethod>> handlers = new ConcurrentDictionary<Type, List<PacketHandlerMethod>>();
        private ConcurrentDictionary<string, Type> registeredPackets = new ConcurrentDictionary<string, Type>();

        /// <summary>
        /// Constructs a new packet dispatcher. In order to have it handle incoming packets add one or
        /// more connections to handle.
        /// </summary>
        public PacketDispatcher()
        {
            this.RegisterBuiltinPackets();
        }

        /// <summary>
        /// Constructs a new packet dispatcher which will handle all incoming packets
        /// for the specified set of connections. See AddConnection for further informations.
        /// </summary>
        /// <param name="connection">The connections the dispatcher should handle.</param>
        public PacketDispatcher(PlayerIOClient.Connection[] connections)
        {
            foreach ( PlayerIOClient.Connection connection in connections )
            {
                this.AddConnection(connection);
            }
        }

        /// <summary>
        /// Adds the specified connection to be handled by the dispatcher. When the the connection gets
        /// flagged as disconnected the connection will be removed from the dispatcher automatically.
        /// </summary>
        /// <param name="connection">The connection to add.</param>
        public void AddConnection(PlayerIOClient.Connection connection)
        {
            if (connection.Connected)
            {
                connections.Add(connection);
                connection.OnDisconnect += delegate(object sender, string message)
                {
                    this.OnDisconnect(connection);
                };
                connection.OnMessage += delegate(object sender, PlayerIOClient.Message message)
                {
                    IInboundPacket packet = this.DeserializeMessage(message);
                    if (packet != null)
                    {
                        this.DispatchPacket(packet);
                    }
                };
            }
        }

        /// <summary>
        /// Registers the given listener to the dispatcher so that all packet handlers
        /// inside it will be notified when the respective packet is received.
        /// </summary>
        /// <param name="listener">The listener to register.</param>
        public void RegisterListener(IPacketListener listener)
        {
            Type type = listener.GetType();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                PacketHandler handler = Attribute.GetCustomAttribute(method, typeof(PacketHandler)) as PacketHandler;
                if (handler == null)
                    // Method is not a handler:
                    continue;

                // This method is a handler so get the type of packet it is designated to:
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length != 1 || !(typeof(IInboundPacket).IsAssignableFrom(parameters[0].ParameterType)))
                    // Packet Handlers must always accept exactly one parameter which is the packet type
                    // they expect:
                    continue;

                // The method is a valid handler, now register it:
                Type packetType = parameters[0].ParameterType;

                if ( this.handlers.ContainsKey( packetType ) )
                {
                    this.handlers[packetType].Add(new PacketHandlerMethod(listener, method));
                }
                else
                {
                    List<PacketHandlerMethod> handlerList = new List<PacketHandlerMethod>();
                    handlerList.Add(new PacketHandlerMethod(listener, method));
                    this.handlers[packetType] = handlerList;
                }
            }
        }

        /// <summary>
        /// Unregisters the given listener from the dispatcher so that all packet
        /// handlers inside it will no longer be notified when the respective packet
        /// is received.
        /// </summary>
        /// <param name="listener"></param>
        public void UnregisterListener(IPacketListener listener)
        {
            Type type = listener.GetType();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                PacketHandler handler = Attribute.GetCustomAttribute(method, typeof(PacketHandler)) as PacketHandler;
                if (handler == null)
                    // Method is not a handler:
                    continue;

                // This method is a handler so get the type of packet it is designated to:
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length != 1 || !(typeof(IInboundPacket).IsAssignableFrom(parameters[0].ParameterType)))
                    // Packet Handlers must always accept exactly one parameter which is the packet type
                    // they expect:
                    continue;

                // The method is a valid handler, now unregister it:
                Type packetType = parameters[0].ParameterType;

                if (this.handlers.ContainsKey(packetType))
                {
                    this.handlers[packetType].Remove(new PacketHandlerMethod(listener, method));
                }
            }
        }

        /// <summary>
        /// Dispatches the given packet to all handlers as appropriate. Using the method
        /// one may even "fake" packets without actually receiving them. Dispatching will
        /// also result in all handlers of possible packet superclasses of the packet's class
        /// to be invoked.
        /// </summary>
        /// <param name="packet">The packet to dispatch.</param>
        public void DispatchPacket(IInboundPacket packet)
        {
            Type packetType = packet.GetType();
            do
            {
                if (this.handlers.ContainsKey(packetType))
                {
                    foreach (PacketHandlerMethod handler in this.handlers[packetType])
                    {
                        try
                        {
                            handler.Method.Invoke(handler.Instance, new object[] { packet });
                        }
                        catch( Exception )
                        {
                            // We cannot afford to miss invoking other handlers only because one has failed to execute
                        }
                    }
                }

                packetType = packetType.BaseType;
            } while (typeof(IInboundPacket).IsAssignableFrom(packetType));
        }

        /// <summary>
        /// Attempts to register the specified packet type. Any packet needs to possess
        /// an PacketInfo attribute at its class declaration which specifies the packet ID.
        /// </summary>
        /// <param name="packetType">The packet type to register.</param>
        /// <returns>True if the registration succeeded, False otherwise.</returns>
        public bool RegisterPacket(Type packetType)
        {
            if (!(typeof(IInboundPacket).IsAssignableFrom(packetType)))
                // Not a packet:
                return false;

            PacketInfo info = Attribute.GetCustomAttribute(packetType, typeof(PacketInfo)) as PacketInfo;
            if (info == null)
                // No packet info:
                return false;

            this.registeredPackets[info.ID] = packetType;
            return true;
        }

        /// <summary>
        /// Registers all packets which come in the same assembly as the packet dispatcher.
        /// </summary>
        private void RegisterBuiltinPackets()
        {
            Assembly assembly = typeof(PacketDispatcher).Assembly;
            IEnumerable<Type> packetTypes = assembly.GetTypes().Where( t => typeof(IInboundPacket).IsAssignableFrom(t) );
            foreach (Type packetType in packetTypes)
            {
                this.RegisterPacket(packetType);
            }
        }

        /// <summary>
        /// Deserializes the specified message and returns the created packet object on success.
        /// </summary>
        /// <param name="message">The message to deserialize.</param>
        /// <returns>The deserialized packet object on success or null on failure.</returns>
        private IInboundPacket DeserializeMessage(PlayerIOClient.Message message)
        {
            if (!this.registeredPackets.ContainsKey(message.Type))
            {
                return null;
            }

            try
            {
                IInboundPacket packet = Activator.CreateInstance(this.registeredPackets[message.Type]) as IInboundPacket;
                packet.Read(message);
                return packet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Handler which will be invoked whenever a message
        /// </summary>
        /// <param name="connection">The connection which disconnected.</param>
        private void OnDisconnect(PlayerIOClient.Connection connection)
        {
            this.connections.Remove(connection);
        }

        private class PacketHandlerMethod : IEquatable<PacketHandlerMethod>
        {
            public object Instance;
            public MethodInfo Method;

            public PacketHandlerMethod(object instance, MethodInfo method)
            {
                this.Instance = instance;
                this.Method = method;
            }


            public override bool Equals(object obj)
            {
                return this.Equals(obj as PacketHandlerMethod);
            }

            public override int GetHashCode()
            {
                int hash = 17;
                if ( Instance != null )
                    hash = hash * 31 + Instance.GetHashCode();
                if ( Method != null )
                    hash = hash * 31 + Method.GetHashCode();
                return hash;
            }

            public bool Equals(PacketHandlerMethod handler)
            {
                if (handler == null)
                    return false;

                return (
                    (
                        Instance == handler.Instance ||
                        Instance != null &&
                        Instance.Equals(handler.Instance)
                    ) &&
                    (
                        Method == handler.Method ||
                        Method != null &&
                        Method.Equals(handler.Method)
                    ) );
            }
        }

    }
}
