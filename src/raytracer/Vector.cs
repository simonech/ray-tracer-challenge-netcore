namespace codeclimber.raytracer
{
    public class Vector
    {
        public static readonly Vector Zero = new Vector(0, 0, 0);
        private Tuple _innerValue;

        public Tuple InnerValue { get => _innerValue; set => _innerValue = value; }

        public Vector(double x, double y, double z) 
        {
            InnerValue = new Tuple(x, y, z, 0);
        }

        public Vector(Tuple tuple)
        {
            InnerValue = tuple;
        }


        public double X { get => _innerValue.X; set => _innerValue.X = value; }
        public double Y { get => _innerValue.Y; set => _innerValue.Y = value; }
        public double Z { get => _innerValue.Z; set => _innerValue.Z = value; }

        public Vector Add(Vector other)
        {
            return new Vector(InnerValue.Add(other.InnerValue));
        }

        public Vector Add(Point other)
        {
            return new Vector(InnerValue.Add(other.InnerValue));
        }

        public Vector Subtract(Vector other)
        {
            return new Vector(InnerValue.Subtract(other.InnerValue));
        }

        public Vector Negate()
        {
            return new Vector(InnerValue.Negate());
        }

        public Vector Multiply(double multiplier)
        {
            return new Vector(InnerValue.Multiply(multiplier));
        }

        public Vector Divide(double divisor)
        {
            return new Vector(InnerValue.Multiply(divisor));
        }

        public double Magnitude()
        {
            return InnerValue.Magnitude();
        }
        public Vector Normalize()
        {
            return new Vector(InnerValue.Normalize());
        }

        public double Dot(Vector other)
        {
            return InnerValue.Dot(other.InnerValue);
        }

        public Vector Cross(Vector other)
        {
            return new Vector(InnerValue.Cross(other.InnerValue));
        }

        public override bool Equals(object obj)
        {
            Vector v = obj as Vector;
            if(v==null)
            {
                return false;
            }
            return InnerValue.Equals(v.InnerValue);
        }

        public override string ToString()
        {
            return InnerValue.ToString();
        }
    }
}