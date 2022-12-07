using AoC2022Days.DayHelpers.Day07;
using NUnit.Framework;
using System.Text;

namespace Aoc2022Days.Test.Day07
{
    [TestFixture]
    public class FolderTest
    {
        [Test]
        [TestCase("dir a", "a")]
        [TestCase("dir d", "d")]
        public void Ctor_WithCorrectInput_ShouldSetName(string input, string name)
        {
            var folder = new AoCFolder(null,input);

            Assert.AreEqual(name, folder.Name);
        }

        [Test]
        public void CalculateSizeOfFolder_WithCorrectInput_ShouldReturnCorrectValue()
        {
            var folderA = new AoCFolder(null, "dir a");
            var folderE = new AoCFolder(null, "dir e");
            folderE.AddFile(new AoCFile("584 i"));
            folderA.AddFile(new AoCFile("29116 f"));
            folderA.AddFile(new AoCFile("2557 g"));
            folderA.AddFile(new AoCFile("62596 h.lst"));
            folderA.AddFolder(folderE);

            var result = folderA.CalculateSizeOfFolder();

            Assert.AreEqual(94853, result);
        }
        [Test]
        public void ToString_ShouldPrintCorrectInfo()
        {
            var folderA = new AoCFolder(null, "dir a");
            var folderE = new AoCFolder(null, "dir e");
            folderE.AddFile(new AoCFile("584 i"));
            folderA.AddFile(new AoCFile("29116 f"));
            folderA.AddFile(new AoCFile("2557 g"));
            folderA.AddFile(new AoCFile("62596 h.lst"));
            folderA.AddFolder(folderE);
            var expectedResult = "  - a (dir)\r\n    - e (dir)\r\n      - i (file, size=584)\r\n    - f (file, size=29116)\r\n    - g (file, size=2557)\r\n    - h.lst (file, size=62596)\r\n";

            var result = folderA.ToString(1);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
