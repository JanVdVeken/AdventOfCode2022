using AoC2022Days.DayHelpers.Day07;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day07
{
    [TestFixture]
    public class FileTest
    {
        [Test]
        [TestCase("14848514 b.txt", "b.txt", 14848514)]
        [TestCase("8033020 d.log", "d.log", 8033020)]
        public void Ctor_WithCorrectInput_ShouldSetNameAndSize(string input, string name, int size)
        {
            var file = new AoCFile(input);
            
            Assert.AreEqual(name, file.Name);
            Assert.AreEqual(size, file.Size);
        }

        [Test]
        public void ToString_ShouldPrintCorrectInfo()
        {
            var file = new AoCFile("14848514 b.txt");

            var result = file.ToString(1);

            Assert.AreEqual("  - b.txt (file, size=14848514)",result);
        }
    }
}
