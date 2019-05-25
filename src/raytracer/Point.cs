namespace codeclimber.raytracer
{
    public class Point
    {
        private Tuple _innerValue;

        public Tuple InnerValue { get => _innerValue; set => _innerValue = value; }

        public Point(double x, double y, double z)
        {
            InnerValue = new Tuple(x, y, z, 1);
        }

        public Point(Tuple tuple)
        {
            InnerValue = tuple;
        }

        public double X { get => _innerValue.X; set => _innerValue.X = value; }
        public double Y { get => _innerValue.Y; set => _innerValue.Y = value; }
        public double Z { get => _innerValue.Z; set => _innerValue.Z = value; }

        public Point Add(Vector other)
        {
            return new Point(InnerValue.Add(other.InnerValue));
        }

        public Vector Subtract(Point other)
        {
            return new Vector(InnerValue.Subtract(other.InnerValue));
        }

        public Point Subtract(Vector other)
        {
            return new Point(InnerValue.Subtract(other.InnerValue));
        }

        public Point Negate()
        {
            return new Point(InnerValue.Negate());
        }

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            if(p==null)
            {
                return false;
            }
            return InnerValue.Equals(p.InnerValue);
        }

        public override string ToString()
        {
            return InnerValue.ToString();
        }
    }
}