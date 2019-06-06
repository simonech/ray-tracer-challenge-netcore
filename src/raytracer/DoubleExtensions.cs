namespace codeclimber.raytracer
{
    using System;
    public static class DoubleExtensions
    {
        private const double EPSILON = 0.00001;

        public static bool EqualsD(this double a, double b)
        {
            if((Math.Abs(a - b))<=EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}