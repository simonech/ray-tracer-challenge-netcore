namespace Chapter1.Projectile
{
    using codeclimber.raytracer;
    public class Projectile
    {
        public Projectile(Point position, Vector velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public Point Position { get; set; }
        public Vector Velocity { get; set; }

        public override string ToString()
        {
            return $"{Position} (v={Velocity})";
        }
    }
}