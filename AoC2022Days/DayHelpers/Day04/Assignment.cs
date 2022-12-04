using System.Transactions;

namespace AoC2022Days.DayHelpers.Day04;

public class Assignment
{
    public int Lower;
    public int Upper;
    public Assignment(string input)
    {
        var temp = input.Split("-");
        Lower = int.Parse(temp[0]);
        Upper = int.Parse(temp[1]);
    }

    public bool ContainsOther(Assignment other)
    {
        return Lower <= other.Lower && Upper >= other.Upper;
    }

    public bool OverlapOther(Assignment other)
    {
        return ContainsOther(other)
               || (Lower >= other.Lower && Lower <= other.Upper)
               || (Upper >= other.Lower && Upper <= other.Upper);
    }
}