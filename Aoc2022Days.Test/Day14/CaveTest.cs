using AoC2022Days.DayHelpers.Day14;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day14
{
    [TestFixture]
    public class CaveTest
    {
        private List<string> testInput = new List<string>() { "498,4 -> 498,6 -> 496,6", "503,4 -> 502,4 -> 502,9 -> 494,9" };
        [Test]
        public void CalculateSandBeforeOverflow_WithTestInput_ShouldReturnCorrectValue()
        {
            List<CaveLine> lineInputs = new List<CaveLine>();
            foreach (var input in testInput.Where(x => !string.IsNullOrEmpty(x)))
            {
                var lines = input.Split(" -> ");
                for (int i = 0; i < lines.Count() - 1; i++)
                {
                    lineInputs.Add(new CaveLine(new CavePoint(lines[i]), new CavePoint(lines[i + 1])));
                }
            }
            var cave = new CavewithoutBottom(lineInputs, new CavePoint("500,0"));
            Console.WriteLine(cave.ToString());
            var result = cave.CalculateSandBeforeOverflow().ToString();
            Console.WriteLine(cave.ToString());
            Assert.AreEqual("24", result);
        }


        [Test]
        public void CalculateSandBeforeOverflowWithFloor_WithTestInput_ShouldReturnCorrectValue()
        {
            List<CaveLine> lineInputs = new List<CaveLine>();
            foreach (var input in testInput.Where(x => !string.IsNullOrEmpty(x)))
            {
                var lines = input.Split(" -> ");
                for (int i = 0; i < lines.Count() - 1; i++)
                {
                    lineInputs.Add(new CaveLine(new CavePoint(lines[i]), new CavePoint(lines[i + 1])));
                }
            }
            var cave = new CaveWithBottom(lineInputs, new CavePoint("500,0"));
            Console.WriteLine(cave.ToString());
            var result = cave.CalculateSandBeforeOverflow().ToString();
            Console.WriteLine(cave.ToString());
            Assert.AreEqual("93", result);
        }
    }
}
