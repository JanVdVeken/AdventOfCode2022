namespace AoC2022Days.DayHelpers.Day09
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;  
        }
        public bool IsNeighbour(Point other)
        {
            for(int i = X-1; i <= X+1;i++)
            {
                for (int j = Y - 1; j <= Y + 1;j++)
                {
                    if (other.X == i && other.Y == j) return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"X:{X} \t Y:{Y}";
        }
    }
}
