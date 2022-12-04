using AoC2022Days.DayHelpers.Day04;
using Common;
using Common.Services;

namespace AoC2022Days;

public class Day04 : Day
{
    public Day04(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        return inputsString.Where(i => !string.IsNullOrEmpty(i))
            .Select(input => new AssignmentPair(input))
            .Count(x => x.ContainEachother()).ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        return inputsString.Where(i => !string.IsNullOrEmpty(i))
            .Select(input => new AssignmentPair(input))
            .Count(x => x.OverlapEachother()).ToString();
    }
}