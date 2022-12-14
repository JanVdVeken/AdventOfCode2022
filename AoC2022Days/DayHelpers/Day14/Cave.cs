using Common.Services;
using System.Reflection.Emit;
using System.Text;

namespace AoC2022Days.DayHelpers.Day14
{
    public abstract class Cave
    {
        protected CavePoint _sandStartingPoint;
        protected int _caveAmountOfCols;
        protected int _lowestUsedCol;
        protected int _caveAmountOfRows;
        protected char[,] _cavePlan;

        protected bool MovePoint(CavePoint current, CavePoint lower)
        {
            if (lower.Y == _caveAmountOfRows) return false;
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
            var upperCol = int.MaxValue;
            var lowerCol = int.MinValue;
            for (int j = 0; j < _caveAmountOfRows - 1; j++)
            {
                for (int i = 0; i < _caveAmountOfCols; i++)
                {
                    if (_cavePlan[i, j] != '.')
                    {
                        upperCol = Math.Min(upperCol, i - 2);
                        lowerCol = Math.Max(lowerCol, i + 2);
                    }
                }

            }
            var sb = new StringBuilder();
            for (int j = 0; j < _caveAmountOfRows; j++)
            {
                for (int i = upperCol; i < lowerCol; i++) sb.Append(_cavePlan[i, j]);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public abstract int CalculateSandBeforeOverflow();
    }
}
