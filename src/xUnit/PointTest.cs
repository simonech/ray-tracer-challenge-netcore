namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class PointTest
    {
        [Fact]
        public void PointIsTupleWithW1()
        {
            var p = Tuple.Point(4f, -4f, 3f);
            var t = new Tuple(4f, -4f, 3f, 1f);
            Assert.Equal(t, p);
            Assert.Equal(p, t);
        }


        [Fact]
        public void PointIsDifferentFromVector()
        {
            var p = Tuple.Point(4.3f, -4.1f, 3.1f);
            var v = Tuple.Vector(4.3f, -4.2f, 3.1f);

            Assert.NotEqual<object>(p, v);
        }
    }
}