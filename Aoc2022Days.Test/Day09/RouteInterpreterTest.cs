using AoC2022Days.DayHelpers.Day09;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day09
{
    [TestFixture]
    public class RouteInterpreterTest
    {
        [Test]
        public void GetPointOfTail_WithGivenInput_ShouldReturnCorrectPoint()
        {
            var input = "R 5\r\nU 8".Split("\r\n")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new Move(char.Parse(x.Split(" ")[0]), int.Parse(x.Split(" ")[1])));
            var routeInterpreter = new RouteInterpreter(input);
            routeInterpreter.CalculateRoute();

            var head = routeInterpreter.GetFullRope()[0];

            Assert.IsTrue(head.Equals(new Point(5,8)));
        }

        [Test]
        [TestCase("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 13)]
        public void AmountOfVisitedPointsSingleTail_WithTestInput_ShouldReturnCorrectValue(string inputs, int expectedResult)
        {
            var routeInterpreter = new RouteInterpreter(inputs.Split("\r\n")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new Move(char.Parse(x.Split(" ")[0]), int.Parse(x.Split(" ")[1]))));
            routeInterpreter.CalculateRoute();

            var result = routeInterpreter.AmountOfVisitedPointsSingleTail();

            Assert.AreEqual(13, result);
        }
        [Test]
        [TestCase("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 1)]
        [TestCase("R 5\r\nU 8\r\nL 8\r\nD 3\r\nR 17\r\nD 10\r\nL 25\r\nU 20", 36)]

        public void AmountOfVisitedPointsLongTail_WithTestInput_ShouldReturnCorrectValue(string inputString, int expectedResult)
        {
            var routeInterpreter = new RouteInterpreter(inputString.Split("\r\n")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new Move(char.Parse(x.Split(" ")[0]), int.Parse(x.Split(" ")[1]))));
            routeInterpreter.CalculateRoute();

            var result = routeInterpreter.AmountOfVisitedPointsLongTail();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetFullRope_WithGivenInput_ShouldReturnCorrectPoints()
        {
            var input = "R 5\r\nU 8".Split("\r\n")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new Move(char.Parse(x.Split(" ")[0]), int.Parse(x.Split(" ")[1])));
            var routeInterpreter = new RouteInterpreter(input);
            routeInterpreter.CalculateRoute();

            var rope = routeInterpreter.GetFullRope();

            Assert.IsTrue(rope[0].Equals(new Point(5, 8)));
            Assert.IsTrue(rope[1].Equals(new Point(5, 7)));
            Assert.IsTrue(rope[4].Equals(new Point(5, 4)));
            Assert.IsTrue(rope[5].Equals(new Point(4, 4)));
            Assert.IsTrue(rope[9].Equals(new Point(0, 0)));
        }
        
    }
}
