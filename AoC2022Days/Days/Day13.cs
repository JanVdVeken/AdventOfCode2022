using AoC2022Days.DayHelpers.Day13;
using Common;
using Common.Services;

namespace AoC2022Days.Days
{
    public class Day13 : Day
    {
        public Day13(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var pairComparers = inputsString.Where(x => !string.IsNullOrEmpty(x))
                 .Select((x, i) => new { Content = x, Indexer = i })
                 .GroupBy(x => x.Indexer / 2)
                 .Select(x => x.ToList())
                 .Select(x => new PairComparer(x.Select(x => x.Content).ToList()))
                 .ToList();
            var returnValue = 0;
            for (int i = 0; i < pairComparers.Count; i++)
            {
                returnValue += pairComparers[i].CalculateOrder() ? i+1 : 0;
            }
            return returnValue.ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var inputs = inputsString.Where(x => !string.IsNullOrEmpty(x)).ToList();
            var fullComparer = new FullComparer(inputs);
            return fullComparer.CalculateCorrectOrder().ToString();
        }
    }
}
