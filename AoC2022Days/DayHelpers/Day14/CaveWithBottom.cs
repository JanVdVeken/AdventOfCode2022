using System.Text;

namespace AoC2022Days.DayHelpers.Day14
{
    public class CaveWithBottom : Cave
    {

        public CaveWithBottom(List<CaveLine> inputs, CavePoint sandStartingPoint)
        {
            _sandStartingPoint = sandStartingPoint;
            var pointsToWallUp = new List<CavePoint>();
            inputs.Select(p => p.GetPointsOfLine().ToList()).ToList()
                .ForEach(pointList => pointList.ForEach(p => pointsToWallUp.Add(p)));

            _caveAmountOfCols = pointsToWallUp.Max(p => p.X) * 2;
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
                _cavePlan[i, _caveAmountOfRows - 1] = '#';
            }
        }

        public override int CalculateSandBeforeOverflow()
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
    }
}
