namespace MessageLib.Math
{
    public class DoubleVector
    {
        // -----------------------------------------------------------------------------------------------
        // Fields
        public double X;
        public double Y;

        // -----------------------------------------------------------------------------------------------
        // Constructors
        public DoubleVector()
        {
            this.X = 0.0D;
            this.Y = 0.0D;
        }

        public DoubleVector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        // -----------------------------------------------------------------------------------------------
        // Operators

        public static DoubleVector operator +(DoubleVector a, DoubleVector b)
        {
            return new DoubleVector(a.X + b.X, a.Y + b.Y);
        }

        public static DoubleVector operator -(DoubleVector a, DoubleVector b)
        {
            return new DoubleVector(a.X - b.X, a.Y - b.Y);
        }

        public static DoubleVector operator *(DoubleVector a, DoubleVector b)
        {
            return new DoubleVector(a.X * b.X, a.Y * b.Y);
        }

        public static DoubleVector operator /(DoubleVector a, DoubleVector b)
        {
            return new DoubleVector(a.X / b.X, a.Y / b.Y);
        }
        
    }
}
