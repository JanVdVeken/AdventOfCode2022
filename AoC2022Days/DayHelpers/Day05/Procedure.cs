namespace AoC2022Days.DayHelpers.Day05
{
    public class Procedure
    {
        public int From;
        public int To;
        public int Times;
        public Procedure(string input)
        {
            var temp = input.Split(" ");
            Times = int.Parse(temp[1]);
            From = int.Parse(temp[3]);
            To = int.Parse(temp[5]);
        }
    }
}
