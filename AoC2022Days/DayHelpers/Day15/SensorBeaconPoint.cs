namespace AoC2022Days.DayHelpers.Day15
{
    public class SensorBeaconPoint
    {
        public readonly int X;
        public readonly int Y;

        public SensorBeaconPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public SensorBeaconPoint(string input)
        {
            var temp = input.Split(',').ToList().Select(x => x.Trim());
            X = int.Parse(temp.First().Replace("x=", ""));
            Y = int.Parse(temp.Last().Replace("y=", ""));
        }

        public bool AreEqual(SensorBeaconPoint other)
        {
            return X == other.X && Y == other.Y;
        }

        public int CalcManhattanDistance(SensorBeaconPoint other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y- other.Y);    
        }

        public override string ToString()
        {
            return $"x: {X}\t y:{Y}";
        }
    }
}
