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
            AddFirstAndLastPartsToVisitedLists();
        }
        public void CalculateRoute()
        {
            _moves.ForEach(move =>{Enumerable.Range(0, move.Times).ToList()
                .ForEach(time =>
                    {
                        _rope[0] = move.IncreasePointWith(_rope.First());
                        for (int tailCounter = 1; tailCounter < tailSize; tailCounter++)
                        {
                            _rope[tailCounter] = _rope[tailCounter].MoveTo(_rope[tailCounter - 1]);
                        }
                        AddFirstAndLastPartsToVisitedLists();
                    });
                }
            );
        }
        private void AddFirstAndLastPartsToVisitedLists()
        {
            var firstPartOfTail = _rope[1];
            if (_visitedPointsSingleTail.All(point => !firstPartOfTail.Equals(point))) _visitedPointsSingleTail.Add(firstPartOfTail);
            var lastPartOfTail = _rope.Last();
            if (_visitedPointsLongTail.All(point => !lastPartOfTail.Equals(point))) _visitedPointsLongTail.Add(lastPartOfTail);
        }
        public List<Point> GetFullRope() => _rope.ToList();
        public int AmountOfVisitedPointsSingleTail() => _visitedPointsSingleTail.Count();
        public int AmountOfVisitedPointsLongTail() => _visitedPointsLongTail.Count();
    }
}
