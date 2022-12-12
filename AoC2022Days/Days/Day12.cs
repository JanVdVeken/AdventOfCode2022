using AoC2022Days.DayHelpers.Day12;
using Common;
using Common.Services;

namespace AoC2022Days.Days
{
    public class Day12 : Day
    {
        public Day12(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var map = new HeightMap(inputsString.Where(x => !string.IsNullOrEmpty(x.Trim())).ToList());
            return map.CalculateFewestSteps().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var map = new HeightMap(inputsString.Where(x => !string.IsNullOrEmpty(x.Trim())).ToList());
            return map.CalculateBestStartingPoint().ToString();
        }
    }
}
