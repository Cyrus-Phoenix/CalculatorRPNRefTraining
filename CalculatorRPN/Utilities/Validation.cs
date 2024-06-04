using CalculatorRPN.Interfaces;
using System.Text.RegularExpressions;

namespace CalculatorRPN.Utilities
{
    internal class Validation
    {
        private readonly IUserInterface _userInterface;
        private readonly List<char> _validCommands = new List<char> { 'q', 'c', '+', '-', '*', '/' };

        public Validation(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public bool IsInputEmpty(string input, string message)
        {
            if (string.IsNullOrEmpty(input))
            {
                _userInterface.Write(message);
                return true;
            }
            return false;
        }

        public bool IsValidCommand(char command, string invalidCommandMessage)
        {
            if (!_validCommands.Contains(command))
            {
                _userInterface.Write(invalidCommandMessage);
                return false;
            }
            return true;
        }

        public string RemoveNonNumericCharacters(string input)
        {
            return Regex.Replace(input, @"[^0-9.]", "");
        }
    }


}
