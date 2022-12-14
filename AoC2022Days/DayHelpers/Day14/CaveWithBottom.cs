using System.Text;

namespace AoC2022Days.DayHelpers.Day14
{
    public class CaveWithBottom
    {
        private readonly CavePoint _sandStartingPoint;
        private readonly int _caveAmountOfCols;
        private readonly int _lowestUsedCol;
        private readonly int _caveAmountOfRows;
        private char[,] _cavePlan;

        public CaveWithBottom(List<CaveLine> inputs, CavePoint sandStartingPoint)
        {
            _sandStartingPoint = sandStartingPoint;
            var pointsToWallUp = new List<CavePoint>();
            inputs.Select(p => p.GetPointsOfLine().ToList()).ToList()
                .ForEach(pointList => pointList.ForEach(p => pointsToWallUp.Add(p)));

            _lowestUsedCol = pointsToWallUp.Min(p => p.X)-10;
            _caveAmountOfCols = pointsToWallUp.Max(p => p.X) *2;
            _caveAmountOfRows = pointsToWallUp.Max(p => p.Y) + 3;
            _cavePlan = new char[_caveAmountOfCols, _caveAmountOfRows];
            for (int i = 0; i < _caveAmountOfCols; i++)
            {
                for (int j = 0; j < _caveAmountOfRows; j++) _cavePlan[i, j] = '.';
            }
            foreach (var point in pointsToWallUp)
            {
                _cavePlan[point.X, point.Y] = '#';
            }
            for (int i = 0; i < _caveAmountOfCols; i++)
            {
                _cavePlan[i, _caveAmountOfRows-1] = '#';
            }
        }

        public int CalculateSandBeforeOverflow()
        {
            var continueDroppingSand = true;
            var count = 0;
            while (continueDroppingSand)
            {
                count++;
                var currentPoint = new CavePoint(_sandStartingPoint.X, _sandStartingPoint.Y);
                _cavePlan[currentPoint.X, currentPoint.Y] = 'o';
                while (true)
                {
                    var oneLower = new CavePoint(currentPoint.X, currentPoint.Y + 1);
                    if (MovePoint(currentPoint, oneLower))
                    {
                        currentPoint = new CavePoint(oneLower.X, oneLower.Y);
                        continue;
                    }
                    oneLower = new CavePoint(currentPoint.X - 1, currentPoint.Y + 1);
                    if (MovePoint(currentPoint, oneLower))
                    {
                        currentPoint = new CavePoint(oneLower.X, oneLower.Y);
                        continue;
                    }
                    oneLower = new CavePoint(currentPoint.X + 1, currentPoint.Y + 1);
                    if (MovePoint(currentPoint, oneLower))
                    {
                        currentPoint = new CavePoint(oneLower.X, oneLower.Y);
                        continue;
                    }
                    if (currentPoint.Y == _sandStartingPoint.Y) continueDroppingSand = false;
                    break;
                }
            }
            return count;
        }

        private bool MovePoint(CavePoint current, CavePoint lower)
        {
            if(lower.Y == _caveAmountOfRows) return false;
            if (_cavePlan[lower.X, lower.Y] == '.')
            {
                _cavePlan[current.X, current.Y] = '.';
                _cavePlan[lower.X, lower.Y] = 'o';
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int j = 0; j < _caveAmountOfRows; j++)
            {
                for (int i = _lowestUsedCol; i < _caveAmountOfCols; i++) sb.Append(_cavePlan[i,j]);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
