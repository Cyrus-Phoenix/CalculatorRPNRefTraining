namespace CalculatorRPN
{
    internal class Controller
    {
        public Controller()
        {
            
        }

        public void RunProgram()
        {

            #region variabels

            string welcomeText = "****Welcome to RPN calculator****";

            string commands = "Commands: " +
                              "\n q:quit " +
                              "\n c:clear " +
                              "\n Number:Number that you want to calculate" +
                              "\n + - * / :Mathematical operators " +
                              "\n []";

            string invalidCommand = "Invalid command, please try again";

            string emptyInputMessage = "You didn't enter any command. Please try again.";

            #endregion



            DoubleStack stack = new DoubleStack();
            Calculator calculator = new Calculator();

            while (true)
            {
                if (stack.Depth == 0)
                {
                    Console.WriteLine(welcomeText);
                    Console.WriteLine(commands);
                }
                else
                {
                    Console.WriteLine(stack.ToString());
                }

                // TODO: kanske skapa string check i en annan class typ stringValidation.validate();
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(emptyInputMessage);
                    continue;
                }

                char command = input[0];
                try
                {
                    // TODO: finns det bättre sätt och göra detta?
                    switch (command)
                    {

                        case var digitCommand when Char.IsDigit(command):
                        double value = Convert.ToDouble(input);
                        stack.Push(value);
                        break;
                        case '+':
                        Calculator.Add(stack);
                        break;
                        case '*':
                        Calculator.Multiply(stack);
                        break;
                        case '-':
                        Calculator.Subtract(stack);
                        break;
                        case '/':
                        Calculator.Divide(stack);
                        break;
                        case 'c':
                        stack.Clear();
                        break;
                        case 'q':
                        return;
                        default:
                        Console.WriteLine(invalidCommand);
                        break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}