using AoC2022Days.DayHelpers.Day10;
using Common;
using Common.Services;

namespace AoC2022Days.Days;

public class Day10 : Day
{
    public Day10(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var instructions = inputsString.Where(x => !string.IsNullOrEmpty(x))
            .Select(x => new Instruction(x))
            .ToList();
        var cpu = new AoCCpu(instructions);

        return cpu.Calculate().ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        throw new NotImplementedException();
    }
}