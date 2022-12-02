using NUnit.Framework;
using AoC2022Days.DayHelpers.Day02;

namespace Aoc2022Days.Test.Day02
{
    [TestFixture]
    public class RockPaperScissorsTest
    {
        List<string> inputList = new List<string>() { "A Y", "B X", "C Z" };

        [Test]
        public void CalculateScore_WithTestInput_ShouldReturn15()
        {
            var expectedResult = 15;
            var result = 0;
            foreach(var input in inputList)
            {
                var temp = new RockPaperScissors(input);
                result += temp.CalculateScore();
            }

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateScoreWithOwnEnding_WithTestInput_ShouldReturn12()
        {
            var expectedResult = 12;
            var result = 0;
            foreach (var input in inputList)
            {
                var temp = new RockPaperScissors(input);
                result += temp.CalculateScoreWithOwnEnding();
            }

            Assert.AreEqual(expectedResult, result);
        }
    }

}
