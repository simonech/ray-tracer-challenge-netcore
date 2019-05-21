namespace codeclimber.raytracer
{
    public class Vector : Tuple
    {
        public static readonly Vector Zero = new Vector(0, 0, 0);
        public Vector(double x, double y, double z) : base(x, y, z, 0) { }

        public Vector Cross(Vector v)
        {
            return new Vector(
                this.Y * v.Z - this.Z * v.Y,
                this.Z * v.X - this.X * v.Z,
                this.X * v.Y - this.Y * v.X
            );
        }
    }
}