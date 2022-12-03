using AoC2022Days.DayHelpers.Day03;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day03;

[TestFixture]
public class GroupTest
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
    public void GetPriority_WithTestInput_ShouldReturn18()
    {
        var group = new Group(new Rucksack(inputs[0]), new Rucksack(inputs[1]), new Rucksack(inputs[2]));
        group.CalculateCommonElement();

        var result = group.GetPriority();
        
        Assert.AreEqual(18,result);
    }
}