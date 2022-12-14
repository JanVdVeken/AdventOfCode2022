using AoC2022Days.DayHelpers.Day14;
using Common;
using Common.Services;

namespace AoC2022Days.Days
{
    public class Day14 : Day
    {
        public Day14(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            List<CaveLine> lineInputs = new List<CaveLine>();
            foreach(var input in inputsString.Where(x => !string.IsNullOrEmpty(x))) 
            {
                var lines = input.Split(" -> ");
                for(int i = 0; i< lines.Count()-1;i++)
                {
                    lineInputs.Add(new CaveLine(new CavePoint(lines[i]), new CavePoint(lines[i + 1])));
                }
            }
            var cave = new CavewithoutBottom(lineInputs,new CavePoint("500,0"));
            return cave.CalculateSandBeforeOverflow().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            List<CaveLine> lineInputs = new List<CaveLine>();
            foreach (var input in inputsString.Where(x => !string.IsNullOrEmpty(x)))
            {
                var lines = input.Split(" -> ");
                for (int i = 0; i < lines.Count() - 1; i++)
                {
                    lineInputs.Add(new CaveLine(new CavePoint(lines[i]), new CavePoint(lines[i + 1])));
                }
            }
            var cave = new CaveWithBottom(lineInputs, new CavePoint("500,0"));
            return cave.CalculateSandBeforeOverflow().ToString();
        }
    }
}
