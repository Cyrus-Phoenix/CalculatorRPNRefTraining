using System.Text;
using CalculatorRPN.Controllers;
using CalculatorRPN.interfaces;

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
