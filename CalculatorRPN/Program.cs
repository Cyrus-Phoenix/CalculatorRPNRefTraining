using System.Text;
using CalculatorRPN.Common;
using CalculatorRPN.Controllers;
using CalculatorRPN.Interfaces;

namespace CalculatorRPN
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            Controller controller = new Controller(userInterface);
            controller.RunProgram();
        }
    }


}
