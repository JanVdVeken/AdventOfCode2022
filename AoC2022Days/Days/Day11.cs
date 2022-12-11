using AoC2022Days.DayHelpers.Day11;
using Common;
using Common.Services;

namespace AoC2022Days.Days;

public class Day11 : Day
{
    public Day11(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var monkeys = inputsString
            .Where(x => !string.IsNullOrEmpty(x))
            .Select((x, i) => new {Content = x, Indexer = i})
            .GroupBy(x => x.Indexer / 6)
            .Select(x => x.ToList())
            .Select(x => new Monkey(x.Select(x => x.Content).ToList()))
            .ToList();
        for (var currentRound = 0; currentRound < 20; currentRound++)
        {
            monkeys.OrderBy(x => x.Id)
                .ToList()
                .ForEach(x => x.CalculateRound(monkeys,3));
        }
        var mostActive = monkeys.OrderByDescending(x => x.InspectionsCounter).First();
        var secondMostActive = monkeys.OrderByDescending(x => x.InspectionsCounter).Skip(1).First();
        return (mostActive.InspectionsCounter * secondMostActive.InspectionsCounter).ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var monkeys = inputsString
            .Where(x => !string.IsNullOrEmpty(x))
            .Select((x, i) => new {Content = x, Indexer = i})
            .GroupBy(x => x.Indexer / 6)
            .Select(x => x.ToList())
            .Select(x => new Monkey(x.Select(x => x.Content).ToList()))
            .ToList();
        var commonDenominator =1;
        monkeys.ForEach(x => commonDenominator *= x.Tester);
        monkeys.ForEach(x => x.SetCommonDenominator(commonDenominator));
        for (var currentRound = 0; currentRound < 10000 ; currentRound++)
        {
            monkeys.OrderBy(x => x.Id)
                .ToList()
                .ForEach(x => x.CalculateRound(monkeys,1));
        }
        var mostActive = monkeys.OrderByDescending(x => x.InspectionsCounter).First();
        var secondMostActive = monkeys.OrderByDescending(x => x.InspectionsCounter).Skip(1).First();
        return (mostActive.InspectionsCounter * secondMostActive.InspectionsCounter).ToString();
    }
}