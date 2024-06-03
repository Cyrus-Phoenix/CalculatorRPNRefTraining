using System;
using System.Text;
using System.Collections.Generic;

namespace CalculatorRPN
{

    // TODO: Förtydliga vad denna klass gör och vad alla otydliga metoder samt variabler gör. Kanske även bryta ut logiker till egna klasser.
    public class DoubleStack
    {
        private double[] data;
        int initialStackSize = 1000;
        public int Depth { get; private set; }

        public DoubleStack()
        {
            data = new double[initialStackSize];
            Depth = 0;
        }

        public void Push(double value)
        {
            data[Depth++] = value;
        }

        public double Pop()
        {
            if (Depth > 0)
            {
                return data[--Depth];
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public double Peek()
        {
            if (Depth > 0)
            {
                return data[Depth - 1];
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public override string ToString() //TODO: är den nödvändig? Finns inte denna biblioteksmetod redan?
        {


            StringBuilder b = new StringBuilder();
            b.Append('[');
            for (int i = Depth - 1; ; i--)
            {
                b.Append(data[i]);
                if (i == 0)
                    return b.Append(']').ToString();
                else { b.Append(", "); }
                
            }

        }

        public void Clear()
        {
            Depth = 0;
        }
    }
}