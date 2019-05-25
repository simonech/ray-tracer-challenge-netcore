namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class PointTest
    {
        [Fact]
        public void PointIsTupleWithW1()
        {
            var p = new Point(4, -4, 3);
            var t = new Tuple(4, -4, 3, 1);
            Assert.Equal(t, p.InnerValue);
            Assert.Equal(p.InnerValue, t);
        }

        [Fact]
        public void EqualityOperatorReturnsTrueWhenEqual()
        {
            var a = new Point(4.3, -4.2, 3.1);
            var b = new Point(4.3, -4.2, 3.1);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.True(ab);
            Assert.True(ba);
        }

        [Fact]
        public void EqualityOperatorReturnsFalseWhenNotEqual()
        {
            var a = new Point(4.3, -4.1, 3.1);
            var b = new Point(4.3, -4.2, 3.1);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.False(ab);
            Assert.False(ba);
        }

        [Fact]
        public void PointIsDifferentFromVector()
        {
            var p = new Point(4.3, -4.1, 3.1);
            var v = new Vector(4.3, -4.2, 3.1);

            Assert.NotEqual<object>(p, v);
        }
        
        [Fact]
        public void CanWriteToString()
        {
        //Given
            var p = new Point(4.3, -4.1, 3.1);
            var expectedResult = "[4.3, -4.1, 3.1],(1)";
        //When
        
        //Then
            Assert.Equal(expectedResult,p.ToString());
        }
    }
}