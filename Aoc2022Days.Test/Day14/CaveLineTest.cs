
using AoC2022Days.DayHelpers.Day14;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day14
{
    [TestFixture]
    public class CaveLineTest
    {
        [Test]
        public void GetPointsOfLine_WithGivenXLine_ShouldReturnCorrectPoints()
        {
            var start = new CavePoint("0,0");
            var end = new CavePoint("10,0");
            var line = new CaveLine(start, end);

            var result = line.GetPointsOfLine().ToList();

            Assert.AreEqual(11, result.Count());
            Assert.IsTrue(result.First().AreEqual(new CavePoint(0, 0)));
            Assert.IsTrue(result[5].AreEqual(new CavePoint(5,0)));
            Assert.IsTrue(result.Last().AreEqual(new CavePoint(10,0)));
        }
        [Test]
        public void GetPointsOfLine_WithGivenYLine_ShouldReturnCorrectPoints()
        {
            var start = new CavePoint("10,20");
            var end = new CavePoint("10,23");
            var line = new CaveLine(start, end);

            var result = line.GetPointsOfLine().ToList();

            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.First().AreEqual(new CavePoint(10, 20)));
            Assert.IsTrue(result[2].AreEqual(new CavePoint(10, 22)));
            Assert.IsTrue(result.Last().AreEqual(new CavePoint(10, 23)));
        }
    }
}
