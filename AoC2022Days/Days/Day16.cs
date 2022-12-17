using AoC2022Days.DayHelpers.Day16;
using Common;
using Common.Services;

namespace AoC2022Days.Days;

public class Day16 : Day
{
    public Day16(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var tunnels = new Tunnels(inputsString.ToList());
        return tunnels.CalulateMostPressure(30,false).ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var tunnels = new Tunnels(inputsString.ToList());
        return tunnels.CalulateMostPressure(26, true).ToString();
    }
}