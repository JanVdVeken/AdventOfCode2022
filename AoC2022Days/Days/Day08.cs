using AoC2022Days.DayHelpers.Day08;
using Common;
using Common.Services;

namespace AoC2022Days.Days;

public class Day08 : Day
{
    public Day08(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var treeMap = new TreeMap(inputsString.Where(x => !string.IsNullOrEmpty(x)).ToList());
        return treeMap.VisibleTreesFromOutside().ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var treeMap = new TreeMap(inputsString.Where(x => !string.IsNullOrEmpty(x)).ToList());
        return treeMap.CalculateHighestScenicScore().ToString();
    }
}