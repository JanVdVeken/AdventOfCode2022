namespace AoC2022Days.DayHelpers.Day10;

public class AoCCpu
{
    private int _x;
    private readonly List<Instruction> _instructions;
    private readonly int[] fixedStrengths = {20, 60, 100, 140, 180, 220};


    public AoCCpu(List<Instruction> instructions)
    {
        _x = 1;
        _instructions = instructions;
    }

    public int CalculateSignalStrength()
    {
        var strength = 0;
        int cycle = 0;
        int currentIndex = 0;
        Instruction currentInstruction = _instructions[currentIndex];
        while (true)
        {
            cycle++;
            if (fixedStrengths.Contains(cycle)) strength += cycle * _x;
            if (!currentInstruction.IsBusy())
            {
                if (++currentIndex >= _instructions.Count) break;
            }

            currentInstruction = _instructions[currentIndex];
            currentInstruction.PassCycle();
            if (!currentInstruction.IsBusy() && currentInstruction.instruction == Instructions.addx)
                _x += currentInstruction.Amount;
        }

        return strength;
    }

    public void DrawCrt()
    {
        _x = 1;
        int cycle = 0;
        int currentIndex = 0;
        Instruction currentInstruction = _instructions[currentIndex];
        while (true)
        {
            cycle++;
            var col = cycle % 40;
            if (!currentInstruction.IsBusy())
            {
                if (++currentIndex >= _instructions.Count) break;
            }

            currentInstruction = _instructions[currentIndex];
            currentInstruction.PassCycle();

            if (!currentInstruction.IsBusy() && currentInstruction.instruction == Instructions.addx)
                _x += currentInstruction.Amount;
            char toWrite = (col == _x || col == _x - 1 || col == _x + 1) ? '#' : '.';

            Console.Write(toWrite);
            if (col == 0) Console.WriteLine();

        }
    }
}