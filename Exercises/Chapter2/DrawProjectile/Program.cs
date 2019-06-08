namespace Chapter2.DrawProjectile
{
    using sys = System;
    using codeclimber.raytracer;

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Projectile(Tuple.Point(0, 1, 0), Tuple.Vector(1, 1.8, 0).Normalize().Multiply(11.3));
            var e = new Environment(Tuple.Vector(0, -0.1, 0), Tuple.Vector(-0.01, 0, 0));
            var c = new Canvas(900, 550);
            while (p.Position.Y >= 0)
            {
                Draw(c, p.Position);
                p = Tick(p, e);
            }
            c.Save("file.ppm");
        }

        private static Projectile Tick(Projectile p, Environment e)
        {
            return new Projectile(
                p.Position.Add(p.Velocity),
                p.Velocity.Add(e.Gravity).Add(e.Wind)
            );
        }

        private static void Draw(Canvas canvas, Tuple position)
        {
            var x = (int)sys.Math.Round(position.X);
            var y = canvas.Height - (int)sys.Math.Round(position.Y) - 1;
            //sys.Console.WriteLine($" {x},{y} - {p}");
            if (x >= 0 && x <= canvas.Width - 1 && y >= 0 && y <= canvas.Height - 1)
            {
                canvas[x, y] = new Color(1, 0, 0);
            }
        }
    }
}
