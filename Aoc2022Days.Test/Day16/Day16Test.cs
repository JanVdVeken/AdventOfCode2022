using AoC2022Days.Days;
using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day16
{
    [TestFixture]
    public class Day16Test
    {
        [Test]
        public void Puzzle2_WithTestInput_ShouldReturnCorrectValue()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day16(inputService, answerService, 16, "Proboscidea Volcanium");

            var result = day.Puzzle2(testInput);

            Assert.AreEqual("1707", result);
        }

        private List<string> testInput = @"Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
                                            Valve BB has flow rate=13; tunnels lead to valves CC, AA
                                            Valve CC has flow rate=2; tunnels lead to valves DD, BB
                                            Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
                                            Valve EE has flow rate=3; tunnels lead to valves FF, DD
                                            Valve FF has flow rate=0; tunnels lead to valves EE, GG
                                            Valve GG has flow rate=0; tunnels lead to valves FF, HH
                                            Valve HH has flow rate=22; tunnel leads to valve GG
                                            Valve II has flow rate=0; tunnels lead to valves AA, JJ
                                            Valve JJ has flow rate=21; tunnel leads to valve II".Split("\r\n").ToList();
    }
}
