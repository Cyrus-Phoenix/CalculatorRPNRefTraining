﻿using CalculatorRPN.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorRPN
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
