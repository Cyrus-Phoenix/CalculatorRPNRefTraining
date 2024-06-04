using CalculatorRPN.interfaces;
using System.Text.RegularExpressions;

namespace CalculatorRPN.Controllers
{
    internal class Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly Validation _validation;
        public Controller(IUserInterface userInterface)
        {
            _userInterface = userInterface;
            _validation = new Validation(userInterface);
        }

        
        public void RunProgram()
        {

            #region variabels

            /* Console Colors */
            string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
            string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
            string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
            string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
            string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
            string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";

            var validNoneDigitCommands = new[] { 'q', 'c', '+', '-', '*', '/' };

            string welcomeText = $@"
                                 {CYAN}   +================================================+
                                    | __        __   _                               |
                                    | \ \      / /__| | ___ ___  _ __ ___   ___      |
                                    |  \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \     |
                                    |   \ V  V /  __/ | (_| (_) | | | | | |  __/     |
                                    |  _ \_/\_/ \___|_|\___\___/|_| |_| |_|\___|     |
                                    | | |_ ___   |  _ \|  _ \| \ | |                 |
                                    | | __/ _ \  | |_) | |_) |  \| |                 |
                                    | | || (_) | |  _ <|  __/| |\  |                 |
                                    |  \__\___/  |_| \_\_|   |_| \_|   _             |
                                    |  / ___|__ _| | ___ _   _| | __ _| |_ ___  _ __ |
                                    | | |   / _` | |/ __| | | | |/ _` | __/ _ \| '__||
                                    | | |__| (_| | | (__| |_| | | (_| | || (_) | |   |
                                    |  \____\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   |
                                    |                                                |
                                    +================================================+{NORMAL}";

            string commands = $@" {MAGENTA}Commands{NORMAL}: 
       {GREEN} q{NORMAL}:  quit 
       {GREEN} c{NORMAL}:  clear
  {GREEN} Number{NORMAL}:  Number that you want to calculate
{GREEN} + - * / {NORMAL}:  Mathematical operators ";

            string invalidCommand = $"\n {RED}*** ERROR: Invalid command, please try again. *** \n {NORMAL}";

            string emptyInputMessage = $"\n {YELLOW}*** WARNING: You didn't enter any command. Please try again. ***\n {NORMAL}";

            #endregion



            DoubleStack stack = new DoubleStack();
            Calculator calculator = new Calculator();

            
            while (true)
            {
                if (stack.Depth == 0)
                {
                    _userInterface.Write(welcomeText);
                    _userInterface.Write("\n" + commands);
                }
                else
                {
                    _userInterface.Write(stack.ToString());
                }

                string input = _userInterface.Read();

                if (_validation.IsInputEmpty(input, emptyInputMessage))
                {
                    continue;
                }

                char command = input[0];

                if (char.IsDigit(command))
                {
                    input = Regex.Replace(input, @"[^0-9.]", "");
                    if (string.IsNullOrEmpty(input))
                    {
                        _userInterface.Write(invalidCommand);
                        continue;
                    }
                }
                else if (!_validation.IsValidCommand(command,invalidCommand))
                {
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
                            _userInterface.Write("\n ************ Goodbye! ************\n");
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