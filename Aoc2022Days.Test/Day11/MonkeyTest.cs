using AoC2022Days.DayHelpers.Day11;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day11;

[TestFixture]
public class MonkeyTest
{
    [Test]
    public void Ctor_WithTestInput_ShouldGenerateCorrectId()
    {
        var monkey = new Monkey(_testInput.Split("\r\n").ToList());

        var result = monkey.Id;
        
        Assert.AreEqual(10,result);
    }
    
  private readonly string _testInput = @"Monkey 10:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3";
}