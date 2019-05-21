using Xunit;

namespace codeclimber.raytracer.xUnit
{
    public class MyMathTest
    {
        [Fact]
        public void CanAddNumbers()
        {
            var math = new MyMath();
            Assert.Equal(4,math.Add(2,2));
        }

        [Fact]
        public void CannotAddNumbers()
        {
            var math = new MyMath();
            Assert.Equal(5,math.Add(2,2));
        }

        [Theory]
        [InlineData(3,3,6)]
        [InlineData(5,3,8)]
        [InlineData(6,1,7)]
        [InlineData(1,1,7)]
        public void MultipleAdditions(int value1, int value2, int result)
        {
            var math = new MyMath();
            Assert.Equal(result,math.Add(value1,value2));
        }
        
    }
}
