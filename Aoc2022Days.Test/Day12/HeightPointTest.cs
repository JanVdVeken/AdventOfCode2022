using AoC2022Days.DayHelpers.Day12;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day12
{
    [TestFixture]
    public class HeightPointTest
    {
        [Test]
        [TestCase('a')]
        [TestCase('e')]
        [TestCase('S')]
        [TestCase('E')]
        public void GetCharValue_WithTestInput_ShouldReturnCorrectValue(char input)
        {
            var point = new HeightPoint(0, 0, input);

            var result = point.GetCharValue();  

            Assert.AreEqual(input, result);
        }
    }
}
