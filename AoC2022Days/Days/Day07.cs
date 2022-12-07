using AoC2022Days.DayHelpers.Day07;
using Common;
using Common.Services;

namespace AoC2022Days;

public class Day07 : Day
{
    public Day07(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var fileSystem = new AoCFileSystem(inputsString.Where(x => !string.IsNullOrEmpty(x)).ToList());
        Console.WriteLine(fileSystem.ToString());
        return fileSystem.CalculateSumOfDirectoriesAtMost(100000).ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var fileSystem = new AoCFileSystem(inputsString.Where(x => !string.IsNullOrEmpty(x)).ToList());
        Console.WriteLine(fileSystem.ToString());
        return fileSystem.GetSizeOfSmallestDirectoryToDelete(30000000).ToString();
    }
}