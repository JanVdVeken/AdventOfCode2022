using AoC2022Days.DayHelpers.Day05;
using Common;
using Common.Services;
using System.Text.RegularExpressions;

namespace AoC2022Days
{
    public class Day05 : Day
    {
        public Day05(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            List<string> startingStacks = inputsString.Where(x => !x.Contains("move") && !string.IsNullOrEmpty(x)).ToList();
            List<Procedure> procedures = inputsString.Where(x => x.Contains("move")).Select(x => new Procedure(x)).ToList();
            var ship = new Ship(startingStacks);
            foreach(Procedure proc in procedures)
            {
                ship.MoveCrateMover9000(proc);
            }
            return ship.GetTopOfStacks();
        }
        

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            List<string> startingStacks = inputsString.Where(x => !x.Contains("move") && !string.IsNullOrEmpty(x)).ToList();
            List<Procedure> procedures = inputsString.Where(x => x.Contains("move")).Select(x => new Procedure(x)).ToList();
            var ship = new Ship(startingStacks);
            foreach (Procedure proc in procedures)
            {
                ship.MoveCrateMover9001(proc);
            }
            return ship.GetTopOfStacks();
        }
    }
}
