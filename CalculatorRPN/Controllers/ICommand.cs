using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorRPN.Controllers
{
    internal interface ICommand
    {
        void Execute(DoubleStack stack);
    }
}
