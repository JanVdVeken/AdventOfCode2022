namespace AoC2022Days.DayHelpers.Day09
{
    public class RouteInterpreter
    {
        private const int tailSize = 9; //10 minus head
        private Point _head;
        private Point[] _tail;

        private readonly List<Move> _moves;

        public RouteInterpreter(IEnumerable<string> inputs)
        {
            _moves = new List<Move>();
            _moves.AddRange(inputs.Select(x => new Move(char.Parse(x.Split(" ")[0]), int.Parse(x.Split(" ")[1]))));
            var startingX = 0;
            var startingY = 0;
            _head = new Point(startingX, startingY);

            _visitedPointsSingleTail = new List<Point>();
            _visitedPointsLongTail = new List<Point>();

            _tail = new Point[tailSize];
            for (int i = 0; i < tailSize; i++)
            {
                _tail[i] = new Point(startingX, startingY);
            }
            AddPointsToTail();
        }
        public void CalculateRoute()
        {
            foreach (var move in _moves)
            {
                for (int i = 0; i < move.Times; i++)
                {
                    switch (move.Direction)
                    {
                        case 'R':
                            _head = new Point(_head.X + 1, _head.Y);
                            break;
                        case 'L':
                            _head = new Point(_head.X - 1, _head.Y);
                            break;
                        case 'U':
                            _head = new Point(_head.X, _head.Y + 1);
                            break;
                        case 'D':
                            _head = new Point(_head.X, _head.Y - 1);
                            break;
                    }
                    _tail[0] = MoveTail(_head, _tail[0]);
                    for (int tailCounter = 1; tailCounter < tailSize; tailCounter++)
                    {
                        _tail[tailCounter] = MoveTail(_tail[tailCounter - 1], _tail[tailCounter]);
                    }
                    AddPointsToTail();
                }
            }
        }
        private List<Point> _visitedPointsSingleTail;
        public int AmountOfVisitedPointsSingleTail() => _visitedPointsSingleTail.Count();
        private List<Point> _visitedPointsLongTail;
        public int AmountOfVisitedPointsLongTail() => _visitedPointsLongTail.Count();

        private void AddPointsToTail()
        {
            var p = _tail.First();
            if (_visitedPointsSingleTail.Any(point => point.X == p.X && point.Y == p.Y) == false) _visitedPointsSingleTail.Add(p);
            p = _tail.Last();
            if (_visitedPointsLongTail.Any(point => point.X == p.X && point.Y == p.Y) == false) _visitedPointsLongTail.Add(p);
        }
        private Point MoveTail(Point head, Point tail)
        {
            if (tail.IsNeighbour(head)) return tail;
            var diffInX = head.X - tail.X;
            var diffInY = head.Y - tail.Y;
            var newX = 0;
            var newY = 0;
            if (Math.Abs(diffInX) >= 1) newX = diffInX / Math.Abs(diffInX);
            if (Math.Abs(diffInY) >= 1) newY = diffInY / Math.Abs(diffInY);
            return new Point(tail.X + newX, tail.Y + newY);
        }

        public Point GetPointOfTail(int index)
        {
            if (index >= tailSize) throw new ArgumentOutOfRangeException($"The maximum length of the tail is {tailSize} (given:{index}))");
            return index == 0 ? _head : _tail[index - 1];
        }

        public List<Point> GetFullRope()
        {
            var temp = new List<Point>() { _head };
            temp.AddRange(_tail);
            return temp;
        }
    }
}
