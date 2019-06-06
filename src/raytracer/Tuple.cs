namespace codeclimber.raytracer
{
    using System;

    public class Tuple
    {
        public static readonly Tuple Zero = new Tuple(0, 0, 0, 0);

        public static Tuple Point(double x, double y, double z)
        {
            return new Tuple(x, y, z, 1);
        }

        public static Tuple Vector(double x, double y, double z)
        {
            return new Tuple(x, y, z, 0);
        }

        public Tuple(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public bool IsPoint { get => W == 1; }
        public bool IsVector { get => W == 0; }


        public Tuple Add(Tuple other)
        {
            return new Tuple(
                X + other.X,
                Y + other.Y,
                Z + other.Z,
                W + other.W
            );
        }

        public Tuple Subtract(Tuple other)
        {
            return new Tuple(
                X - other.X,
                Y - other.Y,
                Z - other.Z,
                W - other.W
            );
        }

        public Tuple Negate()
        {
            return new Tuple(
                -X,
                -Y,
                -Z,
                -W
            );
        }

        public Tuple Multiply(double multiplier)
        {
            return new Tuple(
                X * multiplier,
                Y * multiplier,
                Z * multiplier,
                W * multiplier
            );
        }

        public Tuple Divide(double divisor)
        {
            return new Tuple(
                X / divisor,
                Y / divisor,
                Z / divisor,
                W / divisor
            );
        }

        public double Magnitude()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));
        }

        public Tuple Normalize()
        {
            var m = this.Magnitude();
            return this.Divide(m);
        }

        public double Dot(Tuple other)
        {
            return
                this.X * other.X +
                this.Y * other.Y +
                this.Z * other.Z +
                this.W * other.W;
        }

        public Tuple Cross(Tuple v)
        {
            return new Tuple(
                this.Y * v.Z - this.Z * v.Y,
                this.Z * v.X - this.X * v.Z,
                this.X * v.Y - this.Y * v.X,
                0
            );
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}],({W})";
        }


        public override bool Equals(object obj)
        {
            Tuple t = obj as Tuple;
            Tuple self = this as Tuple;
            if (t == null || self == null)
            {
                return false;
            }
            else
            {
                return (t.X.EqualsD(self.X)
                    && t.Y.EqualsD(self.Y)
                    && t.Z.EqualsD(self.Z)
                    && t.W.EqualsD(self.W));
            }
        }
    }
}