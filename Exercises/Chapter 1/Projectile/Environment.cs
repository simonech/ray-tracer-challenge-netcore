namespace Chapter1.Projectile
{
    using codeclimber.raytracer;
    public class Environment
    {
        public Environment(Tuple gravity, Tuple wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public Tuple Gravity { get; set; }
        public Tuple Wind { get; set; }
    }
}