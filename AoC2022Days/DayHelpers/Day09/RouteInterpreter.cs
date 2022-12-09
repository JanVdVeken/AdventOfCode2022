namespace AoC2022Days.DayHelpers.Day09
{
    public class RouteInterpreter
    {
        private const int tailSize = 10;
        private Point[] _rope;
        private readonly List<Move> _moves;

        private List<Point> _visitedPointsSingleTail;
        private List<Point> _visitedPointsLongTail;

        public RouteInterpreter(IEnumerable<Move> moves)
        {
            _moves = moves.ToList();
            var startingX = 0;
            var startingY = 0;

            _visitedPointsSingleTail = new List<Point>();
            _visitedPointsLongTail = new List<Point>();

            _rope = new Point[tailSize];
            for (int i = 0; i < tailSize; i++)
            {
                _rope[i] = new Point(startingX, startingY);
            }
            AddPointsToTail();
        }
        public void CalculateRoute()
        {
            _moves.ForEach(move =>{Enumerable.Range(0, move.Times).ToList()
                .ForEach(time =>
                    {
                        //move header based on current move
                        _rope[0] = move.MovePoint(_rope.First());

                        //move tail based on previous part of rope
                        for (int tailCounter = 1; tailCounter < tailSize; tailCounter++)
                        {
                            _rope[tailCounter] = _rope[tailCounter].MoveTo(_rope[tailCounter - 1]);
                        }
                        AddPointsToTail();
                    });
                }
            );
        }
        private void AddPointsToTail()
        {
            //rope.first == head
            var p = _rope[1];
            if (_visitedPointsSingleTail.Any(point => point.X == p.X && point.Y == p.Y) == false) _visitedPointsSingleTail.Add(p);
            p = _rope.Last();
            if (_visitedPointsLongTail.Any(point => point.X == p.X && point.Y == p.Y) == false) _visitedPointsLongTail.Add(p);
        }
        public Point GetPointOfTail(int index)
        {
            if (index >= tailSize) throw new ArgumentOutOfRangeException($"The maximum length of the tail is {tailSize} (given:{index}))");
            return _rope[index];
        }

        public List<Point> GetFullRope() => _rope.ToList();
        public int AmountOfVisitedPointsSingleTail() => _visitedPointsSingleTail.Count();
        public int AmountOfVisitedPointsLongTail() => _visitedPointsLongTail.Count();
    }
}
