using System.Text;

namespace AoC2022Days.DayHelpers.Day07;

public class AoCFolder
{
    private readonly string _name;
    public readonly AoCFolder Parent;
    private List<AoCFolder> _folders;
    private List<AoCFile> _files;
    public string Name => _name;
    public AoCFolder(AoCFolder parent, string input)
    {
        Parent = parent;
        _name = input.Replace("dir ", "");
        _folders = new List<AoCFolder>();
        _files = new List<AoCFile>();
    }

    public void AddFolder(AoCFolder folder) => _folders.Add(folder);

    public void AddFile(AoCFile file) => _files.Add(file);

    private int _sizeOfFolder;
    public int CalculateSizeOfFolder()
    {
        if (_sizeOfFolder == 0) _sizeOfFolder = _folders.Select(x => x.CalculateSizeOfFolder()).Sum() + _files.Select(x => x.Size).Sum();
        return _sizeOfFolder;
    }
    public AoCFolder GetFolder(string input) => _folders.SingleOrDefault(x => x.Name == input);

    public int CalculateSumOfDirectoriesAtMost100000()
    {
        var returnValue = 0;
        returnValue += CalculateSizeOfFolder() <= 100000 ? CalculateSizeOfFolder() : 0;
        return returnValue + _folders.Select(f => f.CalculateSumOfDirectoriesAtMost100000()).Sum();
    }

    public List<AoCFolder> GetFoldersWithSizeBiggerThan(int neededSize)
    {
        var correctFolders = new List<AoCFolder>();
        correctFolders.AddRange(_folders.Where(x => x.CalculateSizeOfFolder() >= neededSize));
        _folders.Where(x => x.CalculateSizeOfFolder() >= neededSize)
            .Select(x => x.GetFoldersWithSizeBiggerThan(neededSize))
            .ToList()
            .ForEach(x => correctFolders.AddRange(x));

        return correctFolders;
    }

    public string ToString(int indentations)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(new string(' ',2*indentations));
        sb.AppendLine($"- {_name} (dir)");
        _folders.ForEach(f => sb.Append(f.ToString(indentations + 1)));
        _files.ForEach(f => sb.AppendLine(f.ToString(indentations + 1)));
        return sb.ToString();
    }
}