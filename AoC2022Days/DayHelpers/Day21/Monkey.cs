using System.Security.Cryptography.X509Certificates;

namespace AoC2022Days.DayHelpers.Day21
{
    public class Monkey
    {
        private List<Monkey> _listOfAllMonkeys;
        public String Name;
        private long _number;

        private readonly string _leftMonkey;
        private readonly string _rightMonkey;
        private PossibleOperations _operation;
        public long Number
        {
            get
            {
                if(!string.IsNullOrEmpty(_leftMonkey)) DoOperation();
                return _number;
            }
            set 
            { 
                _number = value; 
            }
        }
        public Monkey(string input)
        {
            Name = input.Split(": ").First().Trim();
            var operationPart = input.Split(": ").Last();
            if (long.TryParse(operationPart, out _number)) return;
            _leftMonkey = operationPart.Split(" ").First().Trim();
            _rightMonkey = operationPart.Split(" ").Last().Trim();
            switch (operationPart.Split(" ")[1].Trim())
            {
                case "+": _operation = PossibleOperations.Add; break;
                case "-": _operation = PossibleOperations.Sub; break;
                case "/": _operation = PossibleOperations.Div; break;
                case "*": _operation = PossibleOperations.Multi; break;
            }
        }

        public void SetListOfAllMonkeys(List<Monkey> monkeys)
        {
            _listOfAllMonkeys = monkeys;
        }

        private void DoOperation()
        {
            var leftMonkey = _listOfAllMonkeys.FirstOrDefault(m => m.Name == _leftMonkey);
            var rightMonkey = _listOfAllMonkeys.FirstOrDefault(m => m.Name == _rightMonkey);
            switch (_operation)
            {
                case PossibleOperations.Add:
                    _number = leftMonkey.Number + rightMonkey.Number; break;
                case PossibleOperations.Sub:
                    _number = leftMonkey.Number - rightMonkey.Number; break;
                case PossibleOperations.Div:
                    _number = leftMonkey.Number / rightMonkey.Number; break;
                case PossibleOperations.Multi:
                    _number = leftMonkey.Number * rightMonkey.Number; break;
            }
        }

        public bool LeftEqualsRight()
        {
            var leftMonkey = _listOfAllMonkeys.FirstOrDefault(m => m.Name == _leftMonkey);
            var rightMonkey = _listOfAllMonkeys.FirstOrDefault(m => m.Name == _rightMonkey);
            return leftMonkey.Number == rightMonkey.Number;
        }
    }
}
