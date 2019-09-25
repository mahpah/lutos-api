using Lutos.Domain.Services;
using Moq;

namespace Lutos.Tests.Domain
{
    public class CalculatorFixture
    {
        public Calculator Calculator { get; }
        public Mock<IBankService> MockBankService { get; private set; }

        public CalculatorFixture()
        {
            MockBankService = new Mock<IBankService>();
            Calculator = new Calculator(MockBankService.Object);
        }
    }
}
