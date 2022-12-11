using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day11;

[TestFixture]
public class Day11Test
{
    [Test]
    public void Puzzle1_WithTestInput_ShouldReturnCorrectValue()
    {
        var answerService = Substitute.For<IAnswerService>();
        var inputService = Substitute.For<IInputService>();
        var day = new AoC2022Days.Days.Day11(inputService,answerService,11,"Monkey in the Middle");

        var result = day.Puzzle1(_testInput);
        
        Assert.AreEqual("10605",result);
    }
    
    [Test]
    public void Puzzle2_WithTestInput_ShouldReturnCorrectValue()
    {
        var answerService = Substitute.For<IAnswerService>();
        var inputService = Substitute.For<IInputService>();
        var day = new AoC2022Days.Days.Day11(inputService,answerService,11,"Monkey in the Middle");

        var result = day.Puzzle2(_testInput);
        
        Assert.AreEqual("2713310158",result);
    }

    private readonly List<string> _testInput = @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1".Split("\r\n").ToList();
}