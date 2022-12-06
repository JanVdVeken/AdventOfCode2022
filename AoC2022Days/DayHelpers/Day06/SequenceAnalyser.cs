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
        var inputArray = _sequence.ToCharArray();
        int i;
        for (i = 0; i < inputArray.Length-disctinctCharacter; i++)
        {
            if(inputArray.SubArray(i, disctinctCharacter).Distinct().Count() == disctinctCharacter) break;
        }
        return i +disctinctCharacter;
    }
    public int CalculateStartOfMessageMarker()
    {
        int disctinctCharacter = 14;
        var inputArray = _sequence.ToCharArray();
        int i;
        for (i = 0; i < inputArray.Length-disctinctCharacter; i++)
        {
            if(inputArray.SubArray(i, disctinctCharacter).Distinct().Count() == disctinctCharacter) break;
        }
        return i +disctinctCharacter;
    }
}