namespace AoC2022Days.DayHelpers.Day06;

public class SequenceAnalyser
{
    private readonly string _sequence;

    public SequenceAnalyser(string sequence)
    {
        _sequence = sequence;
    }
    
    public int CalculateStartOfPacketMarker()
    {
        int disctinctCharacter = 4;
        int i;
        for (i = 0; i < _sequence.Length-disctinctCharacter; i++)
        {
            if(_sequence.Substring(i, disctinctCharacter).Distinct().Count() == disctinctCharacter) break;
        }
        return i +disctinctCharacter;
    }
    public int CalculateStartOfMessageMarker()
    {
        int disctinctCharacter = 14;
        int i;
        for (i = 0; i < _sequence.Length-disctinctCharacter; i++)
        {
            if(_sequence.Substring(i, disctinctCharacter).Distinct().Count() == disctinctCharacter) break;
        }
        return i +disctinctCharacter;
    }
}