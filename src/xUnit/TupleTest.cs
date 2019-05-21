namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class TupleTest
    {
        [Fact]
        public void TupleWithW1IsAPoint()
        {
            //Given
            var a = new Tuple(4.3f,-4.2f,3.1f,1.0f);
            //When
            
            //Then
            Assert.Equal(4.3f,a.X);
            Assert.Equal(-4.2f,a.Y);
            Assert.Equal(3.1f,a.Z);
            Assert.Equal(1.0f,a.W);
            Assert.Equal(TupleType.Point,a.Type);
            Assert.NotEqual(TupleType.Vector,a.Type);
        }
        [Fact]
        public void TupleWithW0IsAVector()
        {
            //Given
            var a = new Tuple(4.3f,-4.2f,3.1f,0.0f);
            //When
            
            //Then
            Assert.Equal(4.3f,a.X);
            Assert.Equal(-4.2f,a.Y);
            Assert.Equal(3.1f,a.Z);
            Assert.Equal(0.0f,a.W);
            Assert.NotEqual(TupleType.Point,a.Type);
            Assert.Equal(TupleType.Vector,a.Type);
        }

        [Fact]
        public void EqualityOperatorReturnsTrueWhenEqual()
        {
            var a = new Tuple(4.3f,-4.2f,3.1f,0.0f);
            var b = new Tuple(4.3f,-4.2f,3.1f,0.0f);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.True(ab);
            Assert.True(ba);
        }

        [Fact]
        public void EqualityOperatorReturnsFalseWhenNotEqual()
        {
            var a = new Tuple(4.3f,-4.1f,3.1f,0.0f);
            var b = new Tuple(4.3f,-4.2f,3.1f,0.0f);

            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.False(ab);
            Assert.False(ba);
        }

        [Fact]
        public void CanAddTuples()
        {
        //Given
            var a1 = new Tuple(3,-2,5,1);
            var a2 = new Tuple(-2,3,1,0);
            var expectedResult = new Tuple(1,1,6,1);
        //When
        
        //Then
            var result = a1.Add(a2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SubtractingPointsGivesAVector()
        {
        //Given
            var a1 = new Point(3,2,1);
            var a2 = new Point(5,6,7);
            var expectedResult = new Vector(-2,-4,-6);
        //When
        
        //Then
            var result = a1.Subtract(a2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SubtractingVectorFromPointGivesAPoint()
        {
        //Given
            var p = new Point(3,2,1);
            var v = new Vector(5,6,7);
            var expectedResult = new Point(-2,-4,-6);
        //When
        
        //Then
            var result = p.Subtract(v);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SubtractingTwoVectorsGivesAVector()
        {
        //Given
            var p = new Vector(3,2,1);
            var v = new Vector(5,6,7);
            var expectedResult = new Vector(-2,-4,-6);
        //When
        
        //Then
            var result = p.Subtract(v);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ZeroVectorIsTuple0000()
        {
        //Given
        var zero = Vector.Zero;
        var zeroTuple = new Tuple(0,0,0,0);
        //When
        
        //Then
        Assert.Equal(zeroTuple,zero);
        }

        [Fact]
        public void SubtractingFromZeroInvertsTheVector()
        {
        //Given
            var zero = Vector.Zero;
            var v = new Vector(1,-2,3);
            var expectedResult = new Vector(-1,2,-3);
        //When
        
        //Then
            var result = zero.Subtract(v);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanNegateTuple()
        {
        //Given
            var t = new Tuple(1,-2,3,-4);
            var expectedResult = new Tuple(-1,2,-3,4);
        //When
        
        //Then
            var result = t.Negate();
            Assert.Equal(expectedResult, result);
        }
    }
}