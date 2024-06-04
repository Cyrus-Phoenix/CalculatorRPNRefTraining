using CalculatorRPN.Models;

namespace CalculatorRPN.Interfaces
{
    internal interface ICommand
    {
        void Execute(DoubleStack stack);
    }
}
