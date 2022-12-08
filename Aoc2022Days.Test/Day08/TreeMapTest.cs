using AoC2022Days.DayHelpers.Day08;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day08;

[TestFixture]
public class TreeMapTest
{
    private List<string> inputs = new List<string>()
    {
        "30373",
        "25512",
        "65332",
        "33549",
        "35390"
    };

    [Test]
    public void Ctor_WithCorrectInput_ShouldGenerateCorrectGrid()
    {
        var trees = new TreeMap(inputs);

        var result1 = trees.GetTree(0,2);
        var result2 = trees.GetTree(3,1);

        Assert.AreEqual(6, result1.Height);
        Assert.AreEqual(1, result2.Height);
    }

    [Test]
    public void VisibleTreesFromOutside_WithGivenInput_ShouldReturnCorrectValue()
    {
        var treeMap = new TreeMap(inputs);

        var result = treeMap.VisibleTreesFromOutside();

        Assert.AreEqual(21, result);
    }

    [Test]
    public void CalculateHighestScenicScore_WithGivenInput_ShouldReturnCorrectValue()
    {
        var treeMap = new TreeMap(inputs);

        var result = treeMap.CalculateHighestScenicScore();

        Assert.AreEqual(8, result);
    }
}