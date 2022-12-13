using AoC2022Days.DayHelpers.Day13;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day13
{
    [TestFixture]
    public class FullComparerTest
    {
        [Test]
        public void CalculateCorrectOrder_WithTestInput_ShouldReturnCorrectValue()
        {
            var fullComparer = new FullComparer(testinput.Where(x => !string.IsNullOrEmpty(x)).ToList());

            var result = fullComparer.CalculateCorrectOrder();

            Assert.AreEqual(140,result);    
        }


        private List<string> testinput = @"[1,1,3,1,1]
                                            [1,1,5,1,1]

                                            [[1],[2,3,4]]
                                            [[1],4]

                                            [9]
                                            [[8,7,6]]

                                            [[4,4],4,4]
                                            [[4,4],4,4,4]

                                            [7,7,7,7]
                                            [7,7,7]

                                            []
                                            [3]

                                            [[[]]]
                                            [[]]

                                            [1,[2,[3,[4,[5,6,7]]]],8,9]
                                            [1,[2,[3,[4,[5,6,0]]]],8,9]".Split("\r\n").ToList();
    }
}
