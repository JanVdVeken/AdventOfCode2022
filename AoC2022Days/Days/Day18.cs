using AoC2022Days.DayHelpers.Day18;
using Common;
using Common.Services;

namespace AoC2022Days.Days;

public class Day18 : Day
{
    public Day18(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
    {
    }

    public override string Puzzle1(IEnumerable<string> inputsString)
    {
        var cubes = inputsString.Where(x => !string.IsNullOrEmpty(x))
            .Select(x => new AoCCube(x)).ToList();
        return cubes.Sum(x => x.CountFreeSides(cubes)).ToString();
    }

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var cubes = inputsString.Where(x => !string.IsNullOrEmpty(x))
            .Select(x => new AoCCube(x)).ToList();
        var minX = cubes.Min(c => c.X);
        var minY = cubes.Min(c => c.Y);
        var minZ = cubes.Min(c => c.Z);
        var maxX = cubes.Max(c => c.X);
        var maxY = cubes.Max(c => c.Y);
        var maxZ = cubes.Max(c => c.Z);
        var count = 0;
        for (int i = minX+1; i < maxX; i++)
        {
            for (int j = minY+1; j < maxY; j++)
            {
                for (int k = minZ+1; k < maxZ; k++)
                {
                    var currentCube= new AoCCube(i,j,k);
                    if (cubes.Any(c => c.AreEqual(currentCube)))
                    {
                        continue;
                    }

                    if (currentCube.HasNeighbour(cubes))
                    {
                        count += 6 - currentCube.CountFreeSides(cubes);
                    }
                    
                }
            }
        }
        return (cubes.Sum(x => x.CountFreeSides(cubes)) - count).ToString();
        
    }
}