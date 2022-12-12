using System.Diagnostics.Contracts;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace AoC2022Days.DayHelpers.Day12
{
    public class HeightMap
    {
        private List<HeightPoint> _points;
        public HeightMap(List<string> input)
        {
            _points = new List<HeightPoint>();
            for (int j = 0; j < input.Count; j++)
            {
                var currentRow = input[j];
                for (int i = 0; i < currentRow.Length; i++)
                {
                    _points.Add(new HeightPoint(i, j, currentRow[i]));
                }
            }
        }

        public int CalculateBestStartingPoint()
        {
            var returnvalue = int.MaxValue;
            _points.ForEach(p => p.ResetDistanceFromStart());
            foreach(var point in _points.Where(x => x.GetCharValue() == 'a'))
            {
                point.UpdateDistanceFromStart(0);
                var endPoint = _points.First(x => x.GetCharValue() == 'E');
                ContinuePath(point, endPoint);
                returnvalue = Math.Min(endPoint.DistanceFromStart, returnvalue);
            }
            return returnvalue;
        }

        public int CalculateFewestSteps()
        {
            var currentPoint = _points.First(x => x.GetCharValue() == 'S');
            currentPoint.UpdateDistanceFromStart(0);
            var endPoint = _points.First(x => x.GetCharValue() == 'E');
            ContinuePath(currentPoint, endPoint);
            return endPoint.DistanceFromStart;
        }


        private void ContinuePath(HeightPoint currentPoint, HeightPoint destinationPoint)
        {
            var possibleNeighbours = GetPossibleNeighbours(currentPoint);
            foreach (var point in possibleNeighbours.Where(p => p.Height <= currentPoint.Height + 1))
            {
                if (point.UpdateDistanceFromStart(currentPoint.DistanceFromStart + 1))
                {
                    ContinuePath(point, destinationPoint);
                }
            }
        }

        public HeightPoint GetPoint(int x, int y)
        {
            HeightPoint inputPoint = new HeightPoint(x, y, 'a');
            return _points.First(p => p.Equals(inputPoint));
        }

        private List<HeightPoint> GetPossibleNeighbours(HeightPoint point)
        {
            return _points.Where(p => (((p.X == point.X - 1 || p.X == point.X + 1) && p.Y == point.Y)
                                   || ((p.Y == point.Y - 1 || p.Y == point.Y + 1) && p.X == point.X)))
                          .Where(p => p.Height <= point.Height + 1)
                          .ToList();
        }
    }
}
