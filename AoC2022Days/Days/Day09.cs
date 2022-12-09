using AoC2022Days.DayHelpers.Day09;
using Common;
using Common.Services;

namespace AoC2022Days.Days
{
    public class Day09 : Day
    {
        public Day09(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var routeInterpreter = new RouteInterpreter(inputsString.Where(x => !string.IsNullOrEmpty(x)));
            routeInterpreter.CalculateRoute();
            return routeInterpreter.AmountOfVisitedPointsSingleTail().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var routeInterpreter = new RouteInterpreter(inputsString.Where(x => !string.IsNullOrEmpty(x)));
            routeInterpreter.CalculateRoute();
            return routeInterpreter.AmountOfVisitedPointsLongTail().ToString();
        }
    }
}
