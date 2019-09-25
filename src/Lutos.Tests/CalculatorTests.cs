using FluentAssertions;
using Lutos.Domain.Aggregates.Common;
using Lutos.Domain.Services;
using Moq;
using Xunit;
using static Lutos.Domain.Aggregates.Common.Currency;

namespace Lutos.Tests
{
    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _fixture;
        private readonly Calculator _calculator;

        public CalculatorTests(CalculatorFixture fixture)
        {
            _fixture = fixture;
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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        public void sum_of_anything_with_zero_is_itself(int a)
        {
            _calculator.Sum(a, 0).Should().Be(a);
        }

        [Fact]
        public void add_one_twice_equal_to_add_two()
        {
            var a = 3;
            var aAdd1 = _calculator.Sum(3, 1);
            var aAdd1Add1 = _calculator.Sum(aAdd1, 1);
            aAdd1Add1.Should().Be(_calculator.Sum(a, 2));
        }

        [Fact]
        public void should_convert_between_currency()
        {
            _fixture.MockBankService
                .Setup(t => t.GetConversionRate(
                    It.Is<Currency>(a => a == Usd),
                    It.Is<Currency>(a => a == Vnd)))
                .Returns(20_000);
            var fiveBuck = new Money(5, Usd);
            var oneThousandDong = new Money(100_000, Vnd);
            _calculator.Convert(fiveBuck, Vnd).Should().Be(oneThousandDong);

            _fixture.MockBankService
                .Verify(t => t.GetConversionRate(
                        It.Is<Currency>(a => a == Usd),
                        It.Is<Currency>(a => a == Vnd)),
                    Times.Once);
        }
    }
}
