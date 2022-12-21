using Common.Services;
using NSubstitute;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day21
{
    [TestFixture]
    public class Day21Test
    {
        [Test]
        public void Puzzle1_WithTestInput_ShouldReturnCorrectValue()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day21(inputService, answerService, 21, "Monkey Math");
            var expectedResult = "152";

            var result = day.Puzzle1(inputs);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Puzzle2_WithTestInput_ShouldReturnCorrectValue()
        {
            var answerService = Substitute.For<IAnswerService>();
            var inputService = Substitute.For<IInputService>();
            var day = new AoC2022Days.Days.Day21(inputService, answerService, 21, "Monkey Math");
            var expectedResult = "301";

            var result = day.Puzzle2(inputs);

            Assert.AreEqual(expectedResult, result);
        }

        private List<string> inputs = @"root: pppw + sjmn
                                        dbpl: 5
                                        cczh: sllz + lgvd
                                        zczc: 2
                                        ptdq: humn - dvpt
                                        dvpt: 3
                                        lfqf: 4
                                        humn: 5
                                        ljgn: 2
                                        sjmn: drzm * dbpl
                                        sllz: 4
                                        pppw: cczh / lfqf
                                        lgvd: ljgn * ptdq
                                        drzm: hmdt - zczc
                                        hmdt: 32".Split("\r\n").ToList();
    }
}
