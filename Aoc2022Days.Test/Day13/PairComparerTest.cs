using AoC2022Days.DayHelpers.Day13;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day13
{
    [TestFixture]
    public class PairComparerTest
    {
        [Test]
        [TestCase("[1,1,3,1,1]", "[1,1,5,1,1]",true)]
        [TestCase("[[1],[2,3,4]]", "[[1],4]", true)]
        [TestCase("[9]", "[[8,7,6]]", false)]
        [TestCase("[[4,4],4,4]", "[[4,4],4,4,4]", true)]
        [TestCase("[7,7,7,7]", "[7,7,7]", false)]
        [TestCase("[]", "[3]", true)]
        [TestCase("[[[]]]", "[[]]", false)]
        [TestCase("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", false)]
        public void CalculateRightOrder_WithGivenTestInput_ShouldReturnCorrectValue(string left, string right,bool rightOrder)
        {
            var inputs = new List<string> { left,right };
            var comparer = new PairComparer(inputs);

            var result = comparer.CalculateOrder();

            Assert.AreEqual(rightOrder, result);
        }
    }
}
