using MessageLib.Math;

namespace MessageLib.Packets.Out
{
    public class PacketPlayerMove : IOutboundPacket
    {
        private DoubleVector position;
        private DoubleVector speed;
        private IntVector modifier;
        private IntVector axes;
        private double gravity;
        private bool spaceDown;

        public DoubleVector Position
        {
            get { return this.position; }
        }

        public DoubleVector Speed
        {
            get { return this.speed; }
        }

        public IntVector Modifier
        {
            get { return this.modifier; }
        }

        public IntVector Axes
        {
            get { return this.axes; }
        }

        public double Gravity
        {
            get { return this.gravity; }
        }

        public bool SpaceDown
        {
            get { return this.spaceDown; }
        }

        // ----------------------------------- Constructor
        public PacketPlayerMove(DoubleVector position, DoubleVector speed, IntVector modifier, IntVector axes, double gravity, bool spaceDown)
        {
            this.position = position;
            this.speed = speed;
            this.modifier = modifier;
            this.axes = axes;
            this.gravity = gravity;
            this.spaceDown = spaceDown;
        }

        // ----------------------------------- IOutboundPacket
        public string MessageType
        {
            get { return "m"; }
        }

        public void Write(PlayerIOClient.Message message)
        {
            message.Add(this.position.X); message.Add(this.position.Y);
            message.Add(this.speed.X); message.Add(this.speed.Y);
            message.Add(this.modifier.X); message.Add(this.modifier.Y);
            message.Add(this.axes.X); message.Add(this.axes.Y);
            message.Add(this.gravity);
            message.Add(this.spaceDown);
        }
    }
}