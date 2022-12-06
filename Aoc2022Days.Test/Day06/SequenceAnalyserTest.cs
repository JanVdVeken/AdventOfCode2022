using AoC2022Days.DayHelpers.Day06;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day06;

[TestFixture]
public class SequenceAnalyserTest
{
    [Test]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz",5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg",6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",11)]
    public void CalculateStartOfPacketMarker_WithGivenInput_ShouldCalculateCorrectOutput(string input, int res)
    {
        var sa = new SequenceAnalyser(input);

        var result = sa.CalculateStartOfPacketMarker();
        
        Assert.AreEqual(res,result);
    }
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb",19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz",23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg",23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",26)]
    public void CalculateStartOfMessageMarker_WithGivenInput_ShouldCalculateCorrectOutput(string input, int res)
    {
        var sa = new SequenceAnalyser(input);

        var result = sa.CalculateStartOfMessageMarker();
        
        Assert.AreEqual(res,result);
    }
}