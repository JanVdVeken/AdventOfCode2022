using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day15
{
    [TestFixture]
    public class Day15Test
    {

        [Test]
        public void Puzzle1_WithTestInput_ShouldReturnCorrectValue()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day15(inputService, answerService, 15, "Beacon Exclusion Zone");
            day.yRowPuzzle1 = 10;
            day.xColPuzzle1 = 200;

            var result = day.Puzzle1(testInput);

            Assert.AreEqual("26", result);
        }
        [Test]
        public void Puzzle2_WithTestInput_ShouldReturnCorrectValue()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day15(inputService, answerService, 15, "Beacon Exclusion Zone");
            day.MinPuzzle2 = 0;
            day.MaxPuzzle2 = 20;

            var result = day.Puzzle2(testInput);

            Assert.AreEqual("56000011", result);
        }

        private List<string> testInput = @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
                                            Sensor at x=9, y=16: closest beacon is at x=10, y=16
                                            Sensor at x=13, y=2: closest beacon is at x=15, y=3
                                            Sensor at x=12, y=14: closest beacon is at x=10, y=16
                                            Sensor at x=10, y=20: closest beacon is at x=10, y=16
                                            Sensor at x=14, y=17: closest beacon is at x=10, y=16
                                            Sensor at x=8, y=7: closest beacon is at x=2, y=10
                                            Sensor at x=2, y=0: closest beacon is at x=2, y=10
                                            Sensor at x=0, y=11: closest beacon is at x=2, y=10
                                            Sensor at x=20, y=14: closest beacon is at x=25, y=17
                                            Sensor at x=17, y=20: closest beacon is at x=21, y=22
                                            Sensor at x=16, y=7: closest beacon is at x=15, y=3
                                            Sensor at x=14, y=3: closest beacon is at x=15, y=3
                                            Sensor at x=20, y=1: closest beacon is at x=15, y=3".Split("\r\n").ToList();
    }
}
