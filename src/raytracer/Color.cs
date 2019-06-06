namespace codeclimber.raytracer
{
    public class Color
    {
        public Color(double r, double g, double b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public Color Add(Color other)
        {
            return new Color(
                Red + other.Red,
                Green + other.Green,
                Blue + other.Blue
            );
        }

        public Color Subtract(Color other)
        {
            return new Color(
                Red - other.Red,
                Green - other.Green,
                Blue - other.Blue
            );
        }

        public Color Multiply(double multiplier)
        {
            return new Color(
                Red * multiplier,
                Green * multiplier,
                Blue * multiplier
            );
        }

        public Color Multiply(Color other)
        {
            return new Color(
                Red * other.Red,
                Green * other.Green,
                Blue * other.Blue
            );
        }

        public override bool Equals(object obj)
        {
            Color t = obj as Color;
            if (t == null)
            {
                return false;
            }
            else
            {
                return (t.Red.EqualsD(Red)
                    && t.Green.EqualsD(Green)
                    && t.Blue.EqualsD(Blue));
            }
        }
    }
}