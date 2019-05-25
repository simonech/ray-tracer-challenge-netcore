namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class VectorTest
    {
        [Fact]
        public void VectorIsTupleWithW0()
        {
            var v = Tuple.Vector(4f, -4f, 3f);
            var t = new Tuple(4f, -4f, 3f, 0);
            Assert.Equal(t, v);
            Assert.Equal(v, t);
        }


        [Fact]
        public void CanComputeCROSSProduct()
        {
            //Given
            var a = Tuple.Vector(1, 2, 3);
            var b = Tuple.Vector(2, 3, 4);
            //When

            //Then
            Assert.Equal(Tuple.Vector(-1, 2, -1), a.Cross(b));
            Assert.Equal(Tuple.Vector(1, -2, 1), b.Cross(a));
        }
    }
}