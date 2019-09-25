using FluentAssertions;
using Lutos.Domain.Services;
using Xunit;

namespace Lutos.Tests
{
    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly Calculator _calculator;

        public CalculatorTests(CalculatorFixture fixture)
        {
            _calculator = fixture.Calculator;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 1, 2)]
        [InlineData(2, -2, 0)]
        public void should_add_two_number(int a, int b, int expectedResult)
        {
            // act
            var sum = _calculator.Sum(a, b);

            // verify
            sum.Should().Be(expectedResult);
        }

        [Fact]
        public void sum_of_a_and_b_should_equal_b_and_a()
        {
            _calculator.Sum(1, 2).Should().Be(_calculator.Sum(2, 1));
        }
    }
}
