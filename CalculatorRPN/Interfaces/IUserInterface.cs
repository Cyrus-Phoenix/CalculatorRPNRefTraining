using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorRPN.interfaces
{
    public interface IUserInterface
    {
        void Write( string message);
        string Read();
    }
}
