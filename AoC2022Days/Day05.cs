using AoC2022Days.DayHelpers.Day05;
using Common;
using Common.Services;

namespace AoC2022Days
{
    public class Day05 : Day
    {
        public Day05(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var ship = new Ship(inputsString.Where(x => !x.Contains("move") && !string.IsNullOrEmpty(x)).ToList());
            inputsString.Where(x => x.Contains("move"))
                .Select(x => new Procedure(x))
                .ToList()
                .ForEach(x => ship.MoveCrateMover9000(x));
            return ship.GetTopOfStacks();
        }
        

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var ship = new Ship(inputsString.Where(x => !x.Contains("move") && !string.IsNullOrEmpty(x)).ToList());
            inputsString.Where(x => x.Contains("move"))
                .Select(x => new Procedure(x))
                .ToList()
                .ForEach(x => ship.MoveCrateMover9001(x));
            return ship.GetTopOfStacks();
        }
    }
}
