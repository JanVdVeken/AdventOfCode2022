using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day02
{
    [TestFixture]
    public class Day02Test
    {
        List<string> inputList = new List<string>() { "A Y", "B X", "C Z" };

        [Test]
        public void Puzzle1_WithTestInput_ShouldReturn15()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day02(inputService, answerService, 2, "Rock Paper Scissors");
            var expectedResult = "15";

            var result = day.Puzzle1(inputList);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Puzzle2_WithTestInput_ShouldReturn12()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day02(inputService, answerService, 2, "Rock Paper Scissors");
            var expectedResult = "12";

            var result = day.Puzzle2(inputList);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
