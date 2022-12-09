namespace AoC2022Days.DayHelpers.Day09
{
    public class Move
    {
        private static Dictionary<char, Point> directions = new Dictionary<char, Point>()
        {
            { 'R',new Point(1, 0) },
            { 'L',new Point(-1,0) },
            { 'U',new Point(0, 1) },
            { 'D',new Point(0,-1) }
        };
        public char Direction { get; }
        public int Times { get; }
        public Move(char direction, int times)
        {
            Direction = direction;
            Times = times;
        }

        public Point UseOn(Point p)
        {
            return new Point(directions[Direction].X + p.X, directions[Direction].Y + p.Y);
        }
    }
}
