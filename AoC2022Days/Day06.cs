using AoC2022Days.DayHelpers.Day06;
using Common;
using Common.Services;

namespace AoC2022Days;

public class Day06 : Day
{
    public Day06(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var sa = new SequenceAnalyser(inputsString.First());
        return sa.CalculateStartOfPacketMarker().ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var sa = new SequenceAnalyser(inputsString.First());
        return sa.CalculateStartOfMessageMarker().ToString();
    }
}