using System;
using System.Text;
using System.Collections.Generic;
using CalculatorRPN.interfaces;

namespace CalculatorRPN
{
    
    public class DoubleStack
    {
        //private double[] data;
        private Stack<double> data;

        public int Depth { get { return data.Count; }}

        //int initialStackSize = 1000;
        //public int Depth { get; private set; }

        public DoubleStack()
        {
            data = new Stack<double>();
            
            //Depth = 0;
        }

        public void Push(double value)
        {
            data.Push(value);
        }

        public double Pop()
        {
            if (data.Count > 0)
            {
                return data.Pop();
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public double Peek()
        {
            if (data.Count > 0)
            {
                return data.Peek();
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", data) + "]";

          /*  StringBuilder b = new StringBuilder();
            b.Append('[');
            for (int i = Depth - 1; ; i--)
            {
                b.Append(data[i]);
                if (i == 0)
                    return b.Append(']').ToString();
                else { b.Append(", "); }
                
            }*/

        }

        public void Clear()
        {
            data.Clear();
        }
    }
}