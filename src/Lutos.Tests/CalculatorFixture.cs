using Lutos.Domain.Services;

namespace Lutos.Tests
{
    public class CalculatorFixture
    {
        private readonly Calculator _calculator;
        public Calculator Calculator => _calculator;
        public CalculatorFixture()
        {
            _calculator = new Calculator();
        }
    }
}
