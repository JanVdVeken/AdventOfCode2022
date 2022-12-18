using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day18;

[TestFixture]
public class Day18Test
{
    [Test]
    public void Puzzle1_WithTestInput_ShouldReturn15()
    {
        var answerService = Substitute.For<IAnswerService>();
        var inputService = Substitute.For<IInputService>();
        var day = new AoC2022Days.Days.Day18(inputService, answerService, 18, "Boiling Boulders");

        var result = day.Puzzle1(inputList);

        Assert.AreEqual("64", result);
    }

    [Test]
    public void Puzzle2_WithTestInput_ShouldReturn15()
    {
        var answerService = Substitute.For<IAnswerService>();
        var inputService = Substitute.For<IInputService>();
        var day = new AoC2022Days.Days.Day18(inputService, answerService, 18, "Boiling Boulders");

        var result = day.Puzzle2(inputList);

        Assert.AreEqual("58", result);
    }

    private List<string> inputList = @"2,2,2
                                        1,2,2
                                        3,2,2
                                        2,1,2
                                        2,3,2
                                        2,2,1
                                        2,2,3
                                        2,2,4
                                        2,2,6
                                        1,2,5
                                        3,2,5
                                        2,1,5
                                        2,3,5".Split("\r\n").ToList();
}