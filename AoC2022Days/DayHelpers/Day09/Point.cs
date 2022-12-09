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
        private bool IsNeighbour(Point other)
        {
            for (int i = X - 1; i <= X + 1; i++)
            {
                for (int j = Y - 1; j <= Y + 1; j++)
                {
                    if (other.X == i && other.Y == j) return true;
                }
            }
            return false;
        }

        public Point MoveTo(Point currentGoal)
        {
            if (IsNeighbour(currentGoal)) return this;
            var diffInX = currentGoal.X - X;
            var diffInY = currentGoal.Y - Y;
            var newX = 0;
            var newY = 0;
            if (Math.Abs(diffInX) >= 1) newX = diffInX / Math.Abs(diffInX);
            if (Math.Abs(diffInY) >= 1) newY = diffInY / Math.Abs(diffInY);
            return new Point(X + newX, Y + newY);
        }
    }
}
