using AoC2022Days.DayHelpers.Day03;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day03;

[TestFixture]
public class RucksackTest
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
    public void Ctor_WithSomeInput_ShouldSplitInputInto2EqualParts()
    {
        var rucksack = new Rucksack(inputs.First());

        var result1 = rucksack.FirstCompartement.Length;
        var result2 = rucksack.SecondCompartement.Length;

        Assert.AreEqual(result1, result2);
    }

    [Test]
    public void CalculateCommonElement_WithFirstTestinput_ShouldReturnp()
    {
        var rucksack = new Rucksack(inputs.First());

        rucksack.CalculateCommonElement();
        var result = rucksack.CommonElement;

        Assert.AreEqual('p', result);
    }
    [Test]
    public void GetPriority_WithFirstTestinput_ShouldReturn16()
    {
        var rucksack = new Rucksack(inputs.First());
        rucksack.CalculateCommonElement();
        
        var result = rucksack.GetPriority();

        Assert.AreEqual(16, result);
    }
}