namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class VectorTest
    {
        [Fact]
        public void VectorIsTupleWithW0()
        {
            var v = new Vector(4, -4, 3);
            var t = new Tuple(4, -4, 3, 0);
            Assert.Equal(t, v.InnerValue);
            Assert.Equal(v.InnerValue, t);
        }

        [Fact]
        public void EqualityOperatorReturnsTrueWhenEqual()
        {
            var a = new Vector(4.3, -4.2, 3.1);
            var b = new Vector(4.3, -4.2, 3.1);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.True(ab);
            Assert.True(ba);
        }

        [Fact]
        public void EqualityOperatorReturnsFalseWhenNotEqual()
        {
            var a = new Vector(4.3, -4.1, 3.1);
            var b = new Vector(4.3, -4.2, 3.1);

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
            var v1=a.Cross(b);
            var v2=b.Cross(a);
            Assert.Equal(new Vector(-1, 2, -1), v1);
            Assert.Equal(new Vector(1, -2, 1), v2);
            Assert.True(v1.InnerValue.IsVector);
            Assert.True(v2.InnerValue.IsVector);
        }

        [Fact]
        public void CanWriteToString()
        {
        //Given
            var v = new Vector(4.3, -4.1, 3.1);
            var expectedResult = "[4.3, -4.1, 3.1],(0)";
        //When
        
        //Then
            Assert.Equal(expectedResult,v.ToString());
        }

    }
}