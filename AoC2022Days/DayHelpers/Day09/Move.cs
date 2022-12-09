namespace AoC2022Days.DayHelpers.Day09
{
    public class Move
    {
        public char Direction { get; }
        public int Times { get; }
        public Move(char direction, int times)
        {
            Direction = direction;
            Times = times;
        }
    }
}
