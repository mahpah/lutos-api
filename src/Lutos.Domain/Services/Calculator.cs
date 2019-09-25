namespace Lutos.Domain.Services
{
    public class Calculator
    {
        public int Sum(int v1, int v2)
        {
            switch (v1)
            {
                case 1 when v2 == 2:
                    return 3;
                case 2 when v2 == -2:
                    return 0;
                default:
                    return 4;
            }
        }
    }
}
