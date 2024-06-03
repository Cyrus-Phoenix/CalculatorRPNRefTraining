using System.Text;
using CalculatorRPN.Controllers;

namespace CalculatorRPN
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.RunProgram();
        }
    }


}
