using System;
using codeclimber.raytracer;

namespace Chapter1.Projectile
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Projectile(new Point(0, 0, 0), new Vector(1, 1, 0));
            var e = new Environment(new Vector(0, -0.1, 0), new Vector(-0.01, 0, 0));
            int i = 0;
            while (p.Position.Y >= 0)
            {
                i++;
                Console.WriteLine($"{i} - {p}");
                p = Update(p, e);
            }
        }

        public static Projectile Update(Projectile p, Environment e)
        {
            return new Projectile(
                p.Position.Add(p.Velocity),
                p.Velocity.Add(e.Gravity).Add(e.Wind)
            );
        }
    }
}
