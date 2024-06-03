namespace CalculatorRPN
{
    internal class Calculator
    {
        public Calculator()
        {
            
        }

        public static void Add(DoubleStack stack)
        {
            stack.Push(stack.Pop() + stack.Pop());
        }

        public static void Divide(DoubleStack stack)
        {
            double secondOperandDivision = stack.Pop();
            stack.Push(stack.Pop() / secondOperandDivision);
        }

        public static void Multiply(DoubleStack stack)
        {
            stack.Push(stack.Pop() * stack.Pop());
        }

        public static void Subtract(DoubleStack stack)
        {
            double secondOperandSubtraction = stack.Pop();
            stack.Push(stack.Pop() - secondOperandSubtraction);
        }
    }
}