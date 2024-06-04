namespace CalculatorRPN.Models
{
    
    public class DoubleStack
    {
        private Stack<double> data;

        public int Depth { get { return data.Count; }}

        public DoubleStack()
        {
            data = new Stack<double>();
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
        }

        public void Clear()
        {
            data.Clear();
        }
    }
}