using AoC2022Days.DayHelpers.Day21;
using Common;
using Common.Services;

namespace AoC2022Days.Days
{
    public class Day21 : Day
    {
        public Day21(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var monkeys = inputsString.Where(s => !string.IsNullOrEmpty(s)).Select(s => new Monkey(s)).ToList();
            monkeys.ForEach(monkey => monkey.SetListOfAllMonkeys(monkeys));
            return monkeys.First(m => m.Name == "root").Number.ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var monkeys = inputsString.Where(s => !string.IsNullOrEmpty(s)).Select(s => new Monkey(s)).ToList();
            monkeys.ForEach(monkey => monkey.SetListOfAllMonkeys(monkeys));
            int i = 0;
            monkeys.First(m => m.Name == "humn").Number = i;
            var rootMonkey = monkeys.First(m => m.Name == "root");
            while (!rootMonkey.LeftEqualsRight())
            {
                i++;
                monkeys.First(m => m.Name == "humn").Number = i;
                if (i % 1000000 == 0) Console.WriteLine(i);
            }
            return monkeys.First(m => m.Name == "humn").Number.ToString();
        }
    }
}
