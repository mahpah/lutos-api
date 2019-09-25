using FluentAssertions;
using Lutos.Domain.Services;
using Xunit;

namespace Lutos.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(1, 1, 2)]
        [InlineData(2, -2, 0)]
        public void should_add_two_number(int a, int b, int expectedResult)
        {
            // setup
            var sut = new Calculator();

            // act
            var sum = sut.Sum(a, b);

            // verify
            sum.Should().Be(expectedResult);
        }
    }
}
