namespace AoC2022Days.DayHelpers.Day14
{
    public class CaveLine
    {
        private readonly CavePoint _start;
        private readonly CavePoint _end;
        public CaveLine(CavePoint start, CavePoint end)
        {
            _start = start;
            _end = end;
        }

        public IEnumerable<CavePoint> GetPointsOfLine()
        {
            CavePoint startPoint;
            CavePoint endPoint;
            if (_end.IsGreaterThan(_start))
            {
                startPoint = _start;
                endPoint = _end;
            }
            else
            {
                startPoint = _end;
                endPoint = _start;
            }
            for (int i = 0; i < endPoint.X - startPoint.X+1; i++)
            {
                for (int j = 0; j < endPoint.Y - startPoint.Y+1; j++)
                { 
                    yield return new CavePoint(startPoint.X+i, startPoint.Y+j);
                }
            }
        }
    }
}
