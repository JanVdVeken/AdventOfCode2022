using AoC2022Days.DayHelpers.Day18;
using Common;
using Common.Services;
using System.Reflection.Metadata.Ecma335;

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
    int _minX;
    int _minY;
    int _minZ;
    int _maxX;
    int _maxY;
    int _maxZ;
    new List<AoCCube> _enclosingCubes;

    public override string Puzzle2(IEnumerable<string> inputsString)
    {
        var cubes = inputsString.Where(x => !string.IsNullOrEmpty(x))
            .Select(x => new AoCCube(x)).ToList();
        _minX = cubes.Min(c => c.X) - 1;
        _minY = cubes.Min(c => c.Y) - 1;
        _minZ = cubes.Min(c => c.Z) - 1;
        _maxX = cubes.Max(c => c.X) + 1;
        _maxY = cubes.Max(c => c.Y) + 1;
        _maxZ = cubes.Max(c => c.Z) + 1;
        _enclosingCubes = new List<AoCCube>();
        var startingCube = new AoCCube(_minX, _minY, _minZ);
        GetAllEnclosingCubes(startingCube, cubes);

        return _enclosingCubes.Sum(p => p.ConnectedToList(cubes)).ToString();
    }

    private void GetAllEnclosingCubes(AoCCube cube, List<AoCCube> allCubes)
    {
        if (cube.X < _minX || cube.X > _maxX
            || cube.Y < _minY || cube.Y > _maxY
            || cube.Z < _minZ || cube.Z > _maxZ) return;
        _enclosingCubes.Add(cube);
        foreach (var neighbour in cube.GetNeighbours())
        {
            if (_enclosingCubes.Any(c => c.AreEqual(neighbour))) continue;
            if (allCubes.Any(c => c.AreEqual(neighbour))) continue;
            GetAllEnclosingCubes(neighbour, allCubes);
        }
    }
}