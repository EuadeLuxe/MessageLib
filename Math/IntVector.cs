namespace MessageLib.Math
{
    public class IntVector
    {
        // -----------------------------------------------------------------------------------------------
        // Fields
        public int X;
        public int Y;

        // -----------------------------------------------------------------------------------------------
        // Constructors
        public IntVector()
        {
            this.X = 0;
            this.Y = 0;
        }

        public IntVector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // -----------------------------------------------------------------------------------------------
        // Operators

        public static IntVector operator +(IntVector a, IntVector b)
        {
            return new IntVector(a.X + b.X, a.Y + b.Y);
        }

        public static IntVector operator -(IntVector a, IntVector b)
        {
            return new IntVector(a.X - b.X, a.Y - b.Y);
        }

        public static IntVector operator *(IntVector a, IntVector b)
        {
            return new IntVector(a.X * b.X, a.Y * b.Y);
        }

        public static IntVector operator /(IntVector a, IntVector b)
        {
            return new IntVector(a.X / b.X, a.Y / b.Y);
        }

    }
}
