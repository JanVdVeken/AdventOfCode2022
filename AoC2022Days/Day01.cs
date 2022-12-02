using Common;
using Common.Services;

namespace AoC2022Days;

public class Day01 : Day
{
    public Day01(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        int currentElf = 0;
        Dictionary<int, long> elfs = new Dictionary<int, long>();
        elfs.Add(currentElf, 0);
        foreach (string input in inputsString)
        {
            if (string.IsNullOrEmpty(input))
            {
                elfs.Add(++currentElf, 0);
                continue;
            }
            elfs[currentElf] += int.Parse(input);
        }
        return elfs.Values.Max(x => x).ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        int currentElf = 0;
        Dictionary<int, long> elfs = new Dictionary<int, long>();
        elfs.Add(currentElf, 0);
        foreach (string input in inputsString)
        {
            if (string.IsNullOrEmpty(input))
            {
                elfs.Add(++currentElf, 0);
                continue;
            }
            elfs[currentElf] += int.Parse(input);
        }
        return elfs.Values.OrderByDescending(x => x).Take(3).Sum().ToString();
    }
}