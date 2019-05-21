namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class PointTest
    {
        [Fact]
        public void PointIsTupleWithW1()
        {
            var p = new Point(4f, -4f, 3f);
            var t = new Tuple(4f, -4f, 3f, 1f);
            Assert.Equal(t, p);
            Assert.Equal(p, t);
        }

        [Fact]
        public void EqualityOperatorReturnsTrueWhenEqual()
        {
            var a = new Point(4.3f, -4.2f, 3.1f);
            var b = new Point(4.3f, -4.2f, 3.1f);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.True(ab);
            Assert.True(ba);
        }

        [Fact]
        public void EqualityOperatorReturnsFalseWhenNotEqual()
        {
            var a = new Point(4.3f, -4.1f, 3.1f);
            var b = new Point(4.3f, -4.2f, 3.1f);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.False(ab);
            Assert.False(ba);
        }

        [Fact]
        public void PointIsDifferentFromVector()
        {
            var p = new Point(4.3f, -4.1f, 3.1f);
            var v = new Vector(4.3f, -4.2f, 3.1f);

            Assert.NotEqual<object>(p, v);
        }
    }
}