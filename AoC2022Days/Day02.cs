using AoC2022Days.DayHelpers.Day02;
using Common;
using Common.Services;

namespace AoC2022Days
{
    public class Day02 : Day
    {
        public Day02(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            return inputsString.Where(i => !string.IsNullOrEmpty(i))
                .Select(input => new RockPaperScissors(input))
                .Select(rps => rps.CalculateScore())
                .Sum()
                .ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            return inputsString.Where(i => !string.IsNullOrEmpty(i))
                .Select(input => new RockPaperScissors(input))
                .Select(rps => rps.CalculateScoreWithOwnEnding())
                .Sum()
                .ToString();
        }
    }
}
