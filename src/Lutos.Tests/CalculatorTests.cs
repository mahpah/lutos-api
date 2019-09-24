using System;
using FluentAssertions;
using Lutos.Domain;
using Xunit;

namespace Lutos.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void should_add_two_number()
        {
            // setup
            var sut = new Calculator();

            // act
            var sum = sut.Sum(2, 2);
            
            // verify
            sum.Should().Equals(4);
        }
    }
}
