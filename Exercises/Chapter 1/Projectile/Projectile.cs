namespace Chapter1.Projectile
{
    using codeclimber.raytracer;
    public class Projectile
    {
        public Projectile(Tuple position, Tuple velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public Tuple Position { get; set; }
        public Tuple Velocity { get; set; }

        public override string ToString()
        {
            return $"{Position} (v={Velocity})";
        }
    }
}