namespace AoC2022Days.DayHelpers.Day06;

public class SequenceAnalyser
{
    private readonly string _sequence;

    public SequenceAnalyser(string sequence)
    {
        _sequence = sequence;
    }

    private int CalculateStartOfMarker(int distinctCharacters)
    {
        int i;
        for (i = 0; i < _sequence.Length - distinctCharacters; i++)
        {
            if (_sequence.Substring(i, distinctCharacters).Distinct().Count() == distinctCharacters) break;
        }
        return i + distinctCharacters;
    }
    
    public int CalculateStartOfPacketMarker()
    {
       return CalculateStartOfMarker(4);
    }
    public int CalculateStartOfMessageMarker()
    {
        return CalculateStartOfMarker(14);
    }
}