namespace AoC2022Days.DayHelpers.Day04;

public class AssignmentPair
{
    private Assignment _firstAssignment;
    private Assignment _secondAssignment;
    public AssignmentPair(string input)
    {
        var temp = input.Split(",");
        _firstAssignment = new Assignment(temp[0]);
        _secondAssignment = new Assignment(temp[1]);
    }

    public bool ContainEachother()
    {
        return _firstAssignment.ContainsOther(_secondAssignment) || _secondAssignment.ContainsOther(_firstAssignment);
    }
    public bool OverlapEachother()
    {
        return _firstAssignment.OverlapOther(_secondAssignment) || _secondAssignment.OverlapOther(_firstAssignment);
    }
    
}