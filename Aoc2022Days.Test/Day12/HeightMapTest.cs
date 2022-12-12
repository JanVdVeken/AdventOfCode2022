
using AoC2022Days.DayHelpers.Day12;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day12
{
    [TestFixture]
    public class HeightMapTest
    {
        [Test]
        [TestCase(5,2,'E')]
        [TestCase(1,4,'b')]
        [TestCase(7,4,'i')]
        public void GetPoint_WithTestInput_ShouldReturnCorrectPoint(int x, int y, char expectedChar)
        {
            var heightMap = new HeightMap(_testInput.Select(x => x.Trim()).ToList());
            var heightPoint = new HeightPoint(x, y, expectedChar);

            var result = heightMap.GetPoint(heightPoint.X, heightPoint.Y);

            Assert.AreEqual(heightPoint.Height, result.Height);
        }
        [Test]
        public void CalculateFewestSteps_WithTestInput_ShouldReturnCorrectValue()
        {
            var heightMap = new HeightMap(_testInput.Select(x => x.Trim()).ToList());

            var result = heightMap.CalculateFewestSteps();

            Assert.AreEqual(31,result);
        }
        [Test]
        public void CalculateBestStartingPoint_WithTestInput_ShouldReturnCorrectValue()
        {
            var heightMap = new HeightMap(_testInput.Select(x => x.Trim()).ToList());

            var result = heightMap.CalculateBestStartingPoint();

            Assert.AreEqual(29, result);
        }

        private readonly List<string> _testInput =  @"Sabqponm
                                                        abcryxxl
                                                        accszExk
                                                        acctuvwj
                                                        abdefghi".Split("\r\n").ToList();
    }
}
