using AoC2022Days.DayHelpers.Day07;
using NUnit.Framework;

namespace Aoc2022Days.Test.Day07
{
    [TestFixture]
    public class AocFileSystemTest
    {
        [Test]
        public void Ctor_WithTestInput_ShouldPrintCorrectOutput()
        {
            var testinput = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k"
                .Split("\r\n").ToList();
            var expectedResult = "- / (dir)\r\n  - a (dir)\r\n    - e (dir)\r\n      - i (file, size=584)\r\n    - f (file, size=29116)\r\n    - g (file, size=2557)\r\n    - h.lst (file, size=62596)\r\n  - d (dir)\r\n    - j (file, size=4060174)\r\n    - d.log (file, size=8033020)\r\n    - d.ext (file, size=5626152)\r\n    - k (file, size=7214296)\r\n  - b.txt (file, size=14848514)\r\n  - c.dat (file, size=8504156)\r\n";
            var fileSystem = new AoCFileSystem(testinput);

            var result = fileSystem.ToString();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateSumOfDirectoriesAtMost100000_WithTestInput_ShouldReturn95437()
        {
            var testinput = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k"
                .Split("\r\n").ToList();
            var expectedResult = 95437;
            var fileSystem = new AoCFileSystem(testinput);

            var result = fileSystem.CalculateSumOfDirectoriesAtMost(100000);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetSizeOfSmallestDirectoryToDelete_WithTestInput_ShouldReturn24933642()
        {
            var testinput = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k"
                .Split("\r\n").ToList();
            var expectedResult = 24933642;
            var fileSystem = new AoCFileSystem(testinput);

            var result = fileSystem.GetSizeOfSmallestDirectoryToDelete(30000000);

            Assert.AreEqual(expectedResult, result);
        }

    }
}
