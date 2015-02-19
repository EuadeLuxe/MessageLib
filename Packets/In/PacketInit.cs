using System.Drawing;

using MessageLib.Math;

namespace MessageLib.Packets.In
{
    [PacketInfo("init")]
    public class PacketInit : IInboundPacket
    {
        public string Owner;
        public string Title;
        public int Plays;
        public int Woots;
        public int TotalWoots;
        public string Rot13;
        public int UserID;
        public IntVector Position;
        public string Username;
        public bool HasCode;
        public bool IsOwner;
        public int Width;
        public int Height;
        public bool IsTutorialRoom;
        public double Gravity;
        public bool AllowPotions;
        public Color BackgroundColor;
        public bool IsRoomVisible;

        private string derot = null;

        /// <summary>
        /// The decpiphered ROT-13 key found inside the init packet.
        /// </summary>
        public string Derot
        {
            get
            {
                if ( this.derot == null )
                {
                    if (this.Rot13 != null)
                    {
                        this.derot = TransformROT13(this.Rot13);
                        return this.derot;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return this.derot;
                }
            }
        }

        public void Read(PlayerIOClient.Message message)
        {
            this.Owner = message.GetString(0);
            this.Title = message.GetString(1);
            this.Plays = message.GetInt(2);
            this.Woots = message.GetInt(3);
            this.TotalWoots = message.GetInt(4);
            this.Rot13 = message.GetString(5);
            this.UserID = message.GetInt(6);
            this.Position = new IntVector(message.GetInt(7), message.GetInt(8));
            this.Username = message.GetString(9);
            this.HasCode = message.GetBoolean(10);
            this.IsOwner = message.GetBoolean(11);
            this.Width = message.GetInt(12);
            this.Height = message.GetInt(13);
            this.IsTutorialRoom = message.GetBoolean(14);
            this.Gravity = message.GetDouble(15);
            this.AllowPotions = message.GetBoolean(16);
            this.BackgroundColor = Color.FromArgb((int)message.GetUInt(17));
            this.IsRoomVisible = message.GetBoolean(18);
        }

        private static string TransformROT13(string rot13)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            char[] chars = rot13.ToCharArray();
            char c = ' ';

            for (int i = 0; i < chars.Length; ++i )
            {
                c = chars[i];
                if ( c >= 'a' && c <= 'z' )
                {
                    if ( c > 'm' )
                        c -= (char) 13;
                    else
                        c += (char) 13;
                } else if ( c >= 'A' && c <= 'Z' ) {
                    if ( c > 'M' )
                        c -= (char) 13;
                    else
                        c += (char) 13;
                }
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}