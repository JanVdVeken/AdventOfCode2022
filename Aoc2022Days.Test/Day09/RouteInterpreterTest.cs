using AoC2022Days.DayHelpers.Day09;
using Common.Services;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day09
{
    [TestFixture]
    public class RouteInterpreterTest
    {

        [Test]
        [TestCase("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 13)]
        public void AmountOfVisitedPointsSingleTail_WithTestInput_ShouldReturnCorrectValue(string inputs, int expectedResult)
        {
            var routeInterpreter = new RouteInterpreter(inputs.Split("\r\n").Where(x => !string.IsNullOrEmpty(x)));
            routeInterpreter.CalculateRoute();

            var result = routeInterpreter.AmountOfVisitedPointsSingleTail();

            Assert.AreEqual(13, result);
        }
        [Test]
        [TestCase("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 1)]
        [TestCase("R 5\r\nU 8\r\nL 8\r\nD 3\r\nR 17\r\nD 10\r\nL 25\r\nU 20", 36)]

        public void AmountOfVisitedPointsLongTail_WithTestInput_ShouldReturnCorrectValue(string inputString, int expectedResult)
        {
            var routeInterpreter = new RouteInterpreter(inputString.Split("\r\n").Where(x => !string.IsNullOrEmpty(x)));
            routeInterpreter.CalculateRoute();

            var result = routeInterpreter.AmountOfVisitedPointsLongTail();

            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void GetPointOfTail_WithGivenInput_ShouldReturnCorrectPoints()
        {
            var input = "R 5\r\nU 8".Split("\r\n").ToList();
            var routeInterpreter = new RouteInterpreter(input);
            routeInterpreter.CalculateRoute();

            var head = routeInterpreter.GetPointOfTail(0);

            Assert.AreEqual(expected: 5, head.X);
            Assert.AreEqual(expected: 8, head.Y);
        }
        [Test]
        public void GetFullRope_WithGivenInput_ShouldReturnCorrectPoints()
        {
            var input = "R 5\r\nU 8".Split("\r\n").ToList();
            var routeInterpreter = new RouteInterpreter(input);

            routeInterpreter.CalculateRoute();

            Assert.AreEqual(expected: 5, routeInterpreter.GetFullRope()[0].X);
            Assert.AreEqual(expected: 8, routeInterpreter.GetFullRope()[0].Y);
            Assert.AreEqual(expected: 5, routeInterpreter.GetFullRope()[1].X);
            Assert.AreEqual(expected: 7, routeInterpreter.GetFullRope()[1].Y);
            Assert.AreEqual(expected: 5, routeInterpreter.GetFullRope()[4].X);
            Assert.AreEqual(expected: 4, routeInterpreter.GetFullRope()[4].Y);
            Assert.AreEqual(expected: 4, routeInterpreter.GetFullRope()[5].X);
            Assert.AreEqual(expected: 4, routeInterpreter.GetFullRope()[5].Y);
            Assert.AreEqual(expected: 0, routeInterpreter.GetFullRope()[9].X);
            Assert.AreEqual(expected: 0, routeInterpreter.GetFullRope()[9].Y);
        }
    }
}
