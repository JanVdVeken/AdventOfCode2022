using AoC2022Days.DayHelpers.Day14;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace Aoc2022Days.Test.Day14
{
    [TestFixture]
    public class CavePointTest
    {
        [Test]
        [TestCase("498,4",498,4)]
        [TestCase("502,9", 502, 9)]
        public void Ctor_WithStringInput_ShouldSetCorrectValues(string input, int expectedX, int expectedY)
        {
            var point = new CavePoint(input);

            var resultX = point.X;
            var resultY = point.Y;

            Assert.AreEqual(expectedX, resultX);
            Assert.AreEqual(expectedY, resultY);
        }
        [Test]
        [TestCase("0,0","0,1",false)]
        [TestCase("0,0","1,0",false)]
        [TestCase("0,3", "0,1", true)]
        [TestCase("3,0", "1,0", true)]
        public void IsGreatThan_WithStringInput_ShouldSetCorrectValues(string input1, string input2, bool expectedResult)
        {
            var point1 = new CavePoint(input1);
            var point2 = new CavePoint(input2);

            var result = point1.IsGreaterThan(point2);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
