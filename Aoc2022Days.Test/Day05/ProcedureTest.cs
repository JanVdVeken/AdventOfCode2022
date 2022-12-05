using AoC2022Days.DayHelpers.Day05;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day05
{
    [TestFixture]
    internal class ProcedureTest
    {
        [Test]
        public void Ctor_WithSomeInput_ShouldSetFromToAndTimes()
        {
            var times = 1;
            var from = 2;
            var to = 3;
            var input = $"move {times} from {from} to {to}";

            var procedure = new Procedure(input);

            Assert.AreEqual(times, procedure.Times);
            Assert.AreEqual(from, procedure.From);
            Assert.AreEqual(to, procedure.To);
        }
    }
}
