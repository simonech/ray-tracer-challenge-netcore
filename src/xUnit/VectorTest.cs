namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class VectorTest
    {
        [Fact]
        public void VectorIsTupleWithW0()
        {
            var v = new Vector(4f, -4f, 3f);
            var t = new Tuple(4f, -4f, 3f, 0);
            Assert.Equal(t, v);
            Assert.Equal(v, t);
        }

        [Fact]
        public void EqualityOperatorReturnsTrueWhenEqual()
        {
            var a = new Vector(4.3f, -4.2f, 3.1f);
            var b = new Vector(4.3f, -4.2f, 3.1f);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.True(ab);
            Assert.True(ba);
        }

        [Fact]
        public void EqualityOperatorReturnsFalseWhenNotEqual()
        {
            var a = new Vector(4.3f, -4.1f, 3.1f);
            var b = new Vector(4.3f, -4.2f, 3.1f);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.False(ab);
            Assert.False(ba);
        }

        [Fact]
        public void CanComputeCROSSProduct()
        {
            //Given
            var a = new Vector(1, 2, 3);
            var b = new Vector(2, 3, 4);
            //When

            //Then
            Assert.Equal(new Vector(-1, 2, -1), a.Cross(b));
            Assert.Equal(new Vector(1, -2, 1), b.Cross(a));
        }
    }
}