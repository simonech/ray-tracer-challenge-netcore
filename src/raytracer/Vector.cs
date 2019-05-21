namespace codeclimber.raytracer
{
    public class Vector : Tuple
    {
        public static readonly Vector Zero = new Vector(0, 0, 0);
        public Vector(double x, double y, double z) : base(x, y, z, 0.0f) { }
    }
}