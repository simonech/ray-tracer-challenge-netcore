namespace codeclimber.raytracer
{
    using System;
    public class Color
    {
        public static readonly Color Black = new Color(0, 0, 0);

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

        public string ToRGB()
        {
            return $"{Normalize(Red)} {Normalize(Green)} {Normalize(Blue)}";
        }

        public string[] ToRGBA()
        {
            return new string[] {Normalize(Red).ToString(), Normalize(Green).ToString(), Normalize(Blue).ToString()};
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

        private int Normalize(double comp)
        {
            if (comp < 0) comp = 0;
            if (comp > 1) comp = 1;

            return (int)Math.Round(255*comp);
        }
    }
}