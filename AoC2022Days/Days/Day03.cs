using AoC2022Days.DayHelpers.Day03;
using Common;
using Common.Services;

namespace AoC2022Days.Days;

public class Day03 : Day
{
    public Day03(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        return inputsString.Where(i => !string.IsNullOrEmpty(i))
            .Select(input =>
            {
                var temp = new Rucksack(input);
                temp.CalculateCommonElement();
                return temp.GetPriority();
            })
            .Sum()
            .ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var rucksackList = inputsString.Where(i => !string.IsNullOrEmpty(i))
            .Select(input => new Rucksack(input)).ToList();
        var totalSum = 0;
        for (int i = 0; i < rucksackList.Count; i = i + 3)
        {
            var temp = new Group(rucksackList[i], rucksackList[i + 1], rucksackList[i + 2]);
            temp.CalculateCommonElement();
            totalSum += temp.GetPriority();
        }

        return totalSum.ToString();
    }
}