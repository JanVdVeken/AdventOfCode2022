using System.Drawing;

namespace AoC2022Days.DayHelpers.Day10;

public class Instruction
{
    public readonly Instructions instruction;
    public readonly int Amount = 0;
    public Instruction(string input)
    {
        var temp = input.Split(" ");
        instruction = Enum.Parse<Instructions>(temp[0]);
        if (instruction == Instructions.addx)
        {
            Amount = int.Parse(temp[1]);
        }
    }
}

public enum Instructions
{
    addx,
    noop,
}