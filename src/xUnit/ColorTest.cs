namespace codeclimber.raytracer.xUnit
{
    using Xunit;

    public class ColorTest
    {
        [Fact]
        public void ColorSetsComponents()
        {
            //Given
            var c = new Color(-0.5, 0.4, 1.7);
            //When

            //Then
            Assert.Equal(-0.5, c.Red);
            Assert.Equal(0.4, c.Green);
            Assert.Equal(1.7, c.Blue);
        }

        [Fact]
        public void CanAddColors()
        {
            //Given
            var a1 = new Color(3, 4, 5);
            var a2 = new Color(2, 3, 1);
            var expectedResult = new Color(5, 7, 6);
            //When

            //Then
            var result = a1.Add(a2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanSubstractColors()
        {
            //Given
            var a1 = new Color(0.9, 0.6, 0.75);
            var a2 = new Color(0.7, 0.1, 0.25);
            var expectedResult = new Color(0.2, 0.5, 0.5);
            //When

            //Then
            var result = a1.Subtract(a2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanMultiplyTimesScalar()
        {
            //Given
            var t = new Color(0.2, 0.3, 0.4);
            var expectedResult = new Color(0.4, 0.6, 0.8);
            //When

            //Then
            var result = t.Multiply(2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CanMultiplyTwoColors()
        {
            //Given
            var a = new Color(1, 0.2, 0.4);
            var b = new Color(0.9, 1, 0.1);
            var expectedResult = new Color(0.9, 0.2, 0.04);
            //When

            //Then
            var result = a.Multiply(b);
            Assert.Equal(expectedResult, result);
        }

    }
}