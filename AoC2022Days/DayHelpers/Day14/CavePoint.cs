namespace AoC2022Days.DayHelpers.Day14
{
    public class CavePoint
    {
        public readonly int X;
        public readonly int Y;

        public CavePoint(int x,int y)
        {
            X = x;
            Y = y;
        }

        public CavePoint(string input)
        {
            var temp = input.Split(',').ToList().Select(x => int.Parse(x.Trim()));
            X = temp.First();
            Y = temp.Last();
        }

        public bool AreEqual(CavePoint other)
        {
            return X == other.X && Y == other.Y;
        }

        public bool IsGreaterThan(CavePoint other)
        {
            return X > other.X || Y > other.Y;
        }
    }
}
