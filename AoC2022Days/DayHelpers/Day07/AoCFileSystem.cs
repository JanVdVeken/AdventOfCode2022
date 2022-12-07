namespace AoC2022Days.DayHelpers.Day07;

public class AoCFileSystem
{
    private const int _MaxSpace = 70000000;
    private AoCFolder _rootFolder;

    private AoCFolder _currentFolder;
    public AoCFileSystem(List<string> inputs)
    {
        _rootFolder = new AoCFolder(null, "/");
        _currentFolder = _rootFolder;
        inputs.ForEach(x => ExecuteCommand(x));
    }

    public void ExecuteCommand(string input)
    {
        if (input.Contains("/")) return;
        if (input.StartsWith("$ ls")) return;
        if (!input.Contains("$"))
        {
            if (input.StartsWith("dir "))
            {
                _currentFolder.AddFolder(new AoCFolder(_currentFolder, input));
                return;
            }
            _currentFolder.AddFile(new AoCFile(input));
            return;
        }
        if (input.StartsWith("$ cd"))
        {
            if (input.Contains(".."))
            {
                _currentFolder = _currentFolder.Parent;
                return;
            }
            _currentFolder = _currentFolder.GetFolder(input.Replace("$ cd ", "").Trim());
        }
    }

    public override string ToString()
    {
        return _rootFolder.ToString(0);
    }

    public int CalculateSumOfDirectoriesAtMost100000()
    {
        return _rootFolder.CalculateSumOfDirectoriesAtMost100000();
    }

    public int GetSizeOfSmallestDirectoryToDelete(int neededFreeSpace)
    {
        var currentFreeSpace = _MaxSpace - _rootFolder.CalculateSizeOfFolder();
        if (currentFreeSpace > neededFreeSpace) return 0;
        var missingFreeSpace = neededFreeSpace - currentFreeSpace;

        return _rootFolder.GetFoldersWithSizeBiggerThan(missingFreeSpace)
            .OrderBy(x => x.CalculateSizeOfFolder())
            .First()
            .CalculateSizeOfFolder();
    }
}