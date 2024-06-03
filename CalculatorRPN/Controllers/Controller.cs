using CalculatorRPN.interfaces;

namespace CalculatorRPN.Controllers
{
    internal class Controller
    {
        private readonly IUserInterface _userInterface;
        public Controller(IUserInterface userInterface)
        {
            _userInterface = userInterface;
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

            //TODO: Försök att bryta ut console så att koden kan återanvändas i andra applikationer.
            while (true)
            {
                if (stack.Depth == 0)
                {
                    _userInterface.Write(welcomeText);
                    _userInterface.Write(commands);
                }
                else
                {
                    _userInterface.Write(stack.ToString());
                }

                // TODO: kanske skapa string check i en annan class typ stringValidation.validate();
                string input = _userInterface.Read();

                if (string.IsNullOrEmpty(input))
                {
                    _userInterface.Write(emptyInputMessage);
                    continue;
                }

                char command = input[0];
                try
                {
                    // TODO: finns det bättre sätt och göra detta? istället för switch
                    switch (command)
                    {

                        case var digitCommand when char.IsDigit(command):
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
                            _userInterface.Write(invalidCommand);
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    _userInterface.Write(ex.Message);
                }

            }
        }
    }
}