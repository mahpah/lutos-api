using System;
using FluentAssertions;
using Lutos.Domain.Aggregates.Common;
using Xunit;
using static Lutos.Domain.Aggregates.Common.Currency;

namespace Lutos.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void money_should_be_created_with_desired_amount_and_currency()
        {
            var fiveBuck = new Money(5, Gbp);
            fiveBuck.Amount.Should().Be(5);
            fiveBuck.Currency.Should().Be(Gbp);
        }

        [Fact]
        public void money_should_have_amount_in_usd_by_default()
        {
            var fiveBuck = new Money(5);
            fiveBuck.Currency.Should().Be(Usd);
        }

        [Fact]
        public void money_cannot_have_negative_amount()
        {
            Action act = () => new Money(-10);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void money_with_the_same_amount_and_currency_are_equal()
        {
            var m1 = new Money(1, Usd);
            m1.Should().Be(new Money(1, Usd));
            m1.Should().NotBe(new Money(1, Gbp));
            m1.Should().NotBe(new Money(2, Usd));
        }
    }
}
