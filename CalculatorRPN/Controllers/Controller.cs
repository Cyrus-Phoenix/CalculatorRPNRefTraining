using CalculatorRPN.interfaces;
using System.Text.RegularExpressions;

namespace CalculatorRPN.Controllers
{
    internal class Controller
    {
        private readonly IUserInterface _userInterface;
        public Controller(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        private bool CheckInput(string input, string message)
        {
            if (string.IsNullOrEmpty(input))
            {
                _userInterface.Write(message);
                return true;
            }
            return false;
        }

        public void RunProgram()
        {

            #region variabels

            var validNoneDigitCommands = new[] { 'q', 'c', '+', '-', '*', '/' };

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
                    _userInterface.Write(welcomeText);
                    _userInterface.Write(commands);
                }
                else
                {
                    _userInterface.Write(stack.ToString());
                }

                string input = _userInterface.Read();

                if (CheckInput(input, emptyInputMessage))
                {
                    continue;
                }

                char command = input[0];

                if (char.IsDigit(command))
                {
                    input = Regex.Replace(input, @"[^0-9.]", "");
                    if (CheckInput(input, invalidCommand))
                    {
                        continue;
                    }
                }
                else if (!validNoneDigitCommands.Contains(command))
                {
                    _userInterface.Write(invalidCommand);
                    continue;
                }

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