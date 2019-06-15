namespace codeclimber.raytracer.xUnit
{
    using Xunit;
    using s = System;

    public class TupleTest
    {
        [Fact]
        public void TupleWithW1IsAPoint()
        {
            //Given
            var a = new Tuple(4.3, -4.2, 3.1, 1);

            //When

            //Then
            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(1, a.W);
            Assert.True(a.IsPoint);
            Assert.False(a.IsVector);

        }
        [Fact]
        public void TupleWithW0IsAVector()
        {
            //Given
            var a = new Tuple(4.3, -4.2, 3.1, 0);

            //When

            //Then
            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(0, a.W);
            Assert.False(a.IsPoint);
            Assert.True(a.IsVector);

        }

        [Fact]
        public void EqualityOperatorReturnsTrueWhenEqual()
        {
            var a = new Tuple(4.3, -4.2, 3.1, 0);
            var b = new Tuple(4.3, -4.2, 3.1, 0);


            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.True(ab);
            Assert.True(ba);
        }

        [Fact]
        public void EqualityOperatorReturnsFalseWhenNotEqual()
        {
            var a = new Tuple(4.3, -4.1, 3.1, 0);
            var b = new Tuple(4.3, -4.2, 3.1, 0);


            var ab = a.Equals(b);
            var ba = b.Equals(a);

            Assert.False(ab);
            Assert.False(ba);
        }

        [Fact]
        public void CanAddTuples()
        {
            //Given
            var a1 = new Tuple(3, -2, 5, 1);
            var a2 = new Tuple(-2, 3, 1, 0);
            var expectedResult = new Tuple(1, 1, 6, 1);
            //When

            //Then
            var result = a1.Add(a2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void AddingVectorToPointGivesAPoint()
        {
            //Given
            var p = Tuple.Point(3, 2, 1);
            var v = Tuple.Vector(5, 6, 7);
            var expectedResult = Tuple.Point(8, 8, 8);
            //When

            //Then
            var result = p.Add(v);
            Assert.Equal(expectedResult, result);
            Assert.True(result.IsPoint);
        }

        [Fact]
        public void SubtractingPointsGivesAVector()
        {
            //Given
            var a1 = Tuple.Point(3, 2, 1);
            var a2 = Tuple.Point(5, 6, 7);
            var expectedResult = Tuple.Vector(-2, -4, -6);
            //When

            //Then
            var result = a1.Subtract(a2);
            Assert.Equal(expectedResult, result);
            Assert.True(result.IsVector);
        }

        [Fact]
        public void SubtractingVectorFromPointGivesAPoint()
        {
            //Given
            var p = Tuple.Point(3, 2, 1);
            var v = Tuple.Vector(5, 6, 7);
            var expectedResult = Tuple.Point(-2, -4, -6);
            //When

            //Then
            var result = p.Subtract(v);
            Assert.Equal(expectedResult, result);
            Assert.True(result.IsPoint);
        }

        [Fact]
        public void SubtractingTwoVectorsGivesAVector()
        {
            //Given
            var v1 = Tuple.Vector(3, 2, 1);
            var v2 = Tuple.Vector(5, 6, 7);
            var expectedResult = Tuple.Vector(-2, -4, -6);
            //When

            //Then
            var result = v1.Subtract(v2);
            Assert.Equal(expectedResult, result);
            Assert.True(result.IsVector);
        }

        [Fact]
        public void ZeroVectorIsTuple0000()
        {
            //Given
            var zero = Tuple.Zero;
            var zeroTuple = new Tuple(0, 0, 0, 0);
            //When

            //Then
            Assert.Equal(zeroTuple, zero);
        }

        [Fact]
        public void SubtractingFromZeroInvertsTheVector()
        {
            //Given
            var zero = Tuple.Zero;
            var v = Tuple.Vector(1, -2, 3);
            var expectedResult = Tuple.Vector(-1, 2, -3);
            //When

            //Then
            var result = zero.Subtract(v);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanNegateTuple()
        {
            //Given
            var t = new Tuple(1, -2, 3, -4);
            var expectedResult = new Tuple(-1, 2, -3, 4);
            //When

            //Then
            var result = t.Negate();
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanMultiplyTimesScalarTuple()
        {
            //Given
            var t = new Tuple(1, -2, 3, -4);
            var expectedResult = new Tuple(3.5f, -7, 10.5f, -14);
            //When

            //Then
            var result = t.Multiply(3.5f);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanMultiplyTimesFractionTuple()
        {
            //Given
            var t = new Tuple(1, -2, 3, -4);
            var expectedResult = new Tuple(0.5f, -1, 1.5f, -2);
            //When

            //Then
            var result = t.Multiply(0.5f);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanDivideTuple()
        {
            //Given
            var t = new Tuple(1, -2, 3, -4);
            var expectedResult = new Tuple(0.5, -1, 1.5, -2);
            //When

            //Then
            var result = t.Divide(2);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1, 0, 0, 1)]
        [InlineData(0, 1, 0, 1)]
        [InlineData(0, 0, 1, 1)]
        public void CanComputeMagnitudeUnitVector(double x, double y, double z, double magnitude)
        {
            var value = Tuple.Vector(x, y, z);
            Assert.Equal(magnitude, value.Magnitude());
        }

        [Fact]
        public void CanComputeMagnitudeVector123()
        {
            //Given
            var value = Tuple.Vector(1, 2, 3);
            var expectedResult = s.Math.Sqrt(14);
            //When

            //Then
            Assert.Equal(expectedResult, value.Magnitude());
        }

        [Fact]
        public void CanComputeMagnitudeVectorNeg123()
        {
            //Given
            var value = Tuple.Vector(-1, -2, -3);
            var expectedResult = s.Math.Sqrt(14);
            //When

            //Then
            Assert.Equal(expectedResult, value.Magnitude());
        }

        [Fact]
        public void CanNormalizeUnidimensionalVector()
        {
            //Given
            var value = Tuple.Vector(4, 0, 0);
            var expectedResult = Tuple.Vector(1, 0, 0);
            //When

            //Then
            Assert.Equal(expectedResult, value.Normalize());
        }

        [Fact]
        public void CanNormalizeBidimensionalVector()
        {
            //Given
            var value = Tuple.Vector(1, 1, 0);
            var sq = s.Math.Sqrt(2);
            var expectedResult = Tuple.Vector(1 / sq, 1 / sq, 0);
            //When

            //Then
            Assert.Equal(expectedResult, value.Normalize());
        }

        [Fact]
        public void CanNormalize3DVector()
        {
            //Given
            var value = Tuple.Vector(1, 2, 3);
            var sq = s.Math.Sqrt(14);
            var expectedResult = Tuple.Vector(1 / sq, 2 / sq, 3 / sq);
            //When

            //Then
            Assert.Equal(expectedResult, value.Normalize());
        }

        [Fact]
        public void MagnitudeOfNormalizedVectorIs1()
        {
            //Given
            var value = Tuple.Vector(1, 2, 3);
            //When
            var norm = value.Normalize();
            //Then
            Assert.Equal(1, norm.Magnitude());
        }

        [Fact]
        public void CanComputeDOTProduct()
        {
            //Given
            var a = Tuple.Vector(1, 2, 3);
            var b = Tuple.Vector(2, 3, 4);
            //When

            //Then
            Assert.Equal(20, a.Dot(b));
        }

        [Fact]
        public void IdenticalUnitVectorsHaveDotProductEqualTo1()
        {
            //Given
            var a = Tuple.Vector(1, 0, 0);
            var b = Tuple.Vector(1, 0, 0);
            //When

            //Then
            Assert.Equal(1, a.Dot(b));
        }

        [Fact]
        public void OppositeUnitVectorsHaveDotProductEqualTo1()
        {
            //Given
            var a = Tuple.Vector(1, 0, 0);
            var b = Tuple.Vector(-1, 0, 0);
            //When

            //Then
            Assert.Equal(-1, a.Dot(b));
        }

        [Fact]
        public void CanWriteToString()
        {
        //Given
            var t = new Tuple(4.3, -4.1, 3.1, 0);
            var expectedResult = "[4.3, -4.1, 3.1],(0)";
        //When
        
        //Then
            Assert.Equal(expectedResult,t.ToString());
        }

    }
}