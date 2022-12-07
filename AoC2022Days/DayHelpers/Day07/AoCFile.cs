using System.Text;

namespace AoC2022Days.DayHelpers.Day07;

public class AoCFile
{
    private readonly string _name;
    private readonly int _size; //does not matter! Motion of the ocean!
    public int Size => _size;
    public string Name => _name;
    public AoCFile(string input)
    {
        var temp = input.Trim().Split(" ");
        _size = int.Parse(temp[0].Trim());
        _name = temp[1].Trim();
    }

    public string ToString(int indentations)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(new string(' ', 2 * indentations));
        sb.Append($"- {_name} (file, size={_size})");
        return sb.ToString();
    }
}
