using CalculatorRPN.Interfaces;

namespace CalculatorRPN.Common
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public string Read()
        {
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }
    }
}
