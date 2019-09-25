using Lutos.Domain.Services;
using Moq;

namespace Lutos.Tests
{
    public class CalculatorFixture
    {
        private readonly Calculator _calculator;
        public Calculator Calculator => _calculator;
        public Mock<IBankService> MockBankService { get; private set; }

        public CalculatorFixture()
        {
            MockBankService = new Mock<IBankService>();
            _calculator = new Calculator(MockBankService.Object);
        }
    }
}
