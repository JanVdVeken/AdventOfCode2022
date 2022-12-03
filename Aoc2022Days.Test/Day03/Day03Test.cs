using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day03;
[TestFixture]
public class Day03Test
{
    private List<string> inputs = new List<string>()
    {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    };
    [Test]
    public void Puzzle1_WithTestInput_ShouldReturn157()
    {
        var answerService = Substitute.For<IAnswerService>();
        var inputService = Substitute.For<IInputService>();
        var day = new AoC2022Days.Day03(inputService, answerService, 3, "Rucksack Reorganization");
        var expectedResult = "157";

        var result = day.Puzzle1(inputs);

        Assert.AreEqual(expectedResult, result);
    }
    [Test]
    public void Puzzle2_WithTestInput_ShouldReturn70()
    {
        var answerService = Substitute.For<IAnswerService>();
        var inputService = Substitute.For<IInputService>();
        var day = new AoC2022Days.Day03(inputService, answerService, 3, "Rucksack Reorganization");
        var expectedResult = "70";

        var result = day.Puzzle2(inputs);

        Assert.AreEqual(expectedResult, result);
    }
}