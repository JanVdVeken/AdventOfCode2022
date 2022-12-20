using System.Reflection.Metadata.Ecma335;

namespace AoC2022Days.DayHelpers.Day18;

public class AoCCube
{
    public int X;
    public int Y;
    public int Z;

    public AoCCube(string input)
    {
        var temp = input.Split(",");
        X = int.Parse(temp[0]);
        Y = int.Parse(temp[1]);
        Z = int.Parse(temp[2]);
    }
    public AoCCube(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public int CountFreeSides(List<AoCCube> cubes)
    {
        return 6 - cubes.Count(c => (c.X == X && c.Y == Y && (c.Z == Z + 1 || c.Z == Z - 1))
                                || (c.X == X && c.Z == Z && (c.Y == Y - 1 || c.Y == Y + 1))
                                || (c.Y == Y && c.Z == Z && (c.X == X - 1 || c.X == X + 1)));
    }
    public int ConnectedToList(List<AoCCube> cubes)
    {
        return cubes.Count(c => (c.X == X && c.Y == Y && (c.Z == Z + 1 || c.Z == Z - 1))
                                || (c.X == X && c.Z == Z && (c.Y == Y - 1 || c.Y == Y + 1))
                                || (c.Y == Y && c.Z == Z && (c.X == X - 1 || c.X == X + 1)));
    }


    public bool AreEqual(AoCCube other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public IEnumerable<AoCCube> GetNeighbours()
    {
        for (int k = -1; k < 2; k++)
        {
            yield return new AoCCube(X+k , Y, Z);
        }
        for (int k = -1; k < 2; k++)
        {
            yield return new AoCCube(X, Y + k, Z);
        }
        for (int k = -1; k < 2; k++)
        {
            yield return new AoCCube(X, Y, Z + k);
        }
    }
}