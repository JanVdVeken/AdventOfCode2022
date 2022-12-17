using AoC2022Days.DayHelpers.Day16;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day16
{
    [TestFixture]
    public class TunnelsTest
    {
        [Test]
        public void Ctor_WithTestInput_ShouldCreateCorrectAmountOfValves()
        {
            var tunnels = new Tunnels(testInput);

            var result = tunnels.Valves;

            Assert.AreEqual(10, result.Count);
        }
        [Test]
        public void CalulateMostPressureWithOutHelper_WithTestInput_ShouldReturnCorrectValue()
        {
            var tunnels = new Tunnels(testInput);

            var result = tunnels.CalulateMostPressure(30,false);

            Assert.AreEqual(1651, result);
        }
        [Test]
        public void CalulateMostPressureWithHelper_WithTestInput_ShouldReturnCorrectValue()
        {
            var tunnels = new Tunnels(testInput);

            var result = tunnels.CalulateMostPressure(26, true);

            Assert.AreEqual(1707, result);
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
