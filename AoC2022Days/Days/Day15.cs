using AoC2022Days.DayHelpers.Day15;
using Common;
using Common.Services;

namespace AoC2022Days.Days
{
    public class Day15 : Day
    {
        public int yRowPuzzle1 = 2000000;
        public int xColPuzzle1 = 10000000;
        public int MinPuzzle2 = 0;
        public int MaxPuzzle2 = 4000000;
        public Day15(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle) : base(inputService, answerService, dayNumber, dayTitle)
        {
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            List<SensorBeaconPair> sensorBeaconPair = inputsString.Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Replace("Sensor at ", ""))
                .Select(x => x.Replace(" closest beacon is at ", ""))
                .Select(x => x.Split(":"))
                .Select(x => new SensorBeaconPair(new SensorBeaconPoint(x.First()), new SensorBeaconPoint(x.Last())))
                .ToList();
            var count = 0;
            for (int currentX = -xColPuzzle1; currentX < xColPuzzle1; currentX++)
            {
                var currentPoint = new SensorBeaconPoint(currentX, yRowPuzzle1);
                foreach (var pair in sensorBeaconPair)
                {
                    if (!pair.BeaconCanBePresent(currentPoint) && !pair.Beacon.AreEqual(currentPoint))
                    {
                        count++;
                        break;
                    }
                }
            }
            return count.ToString();

        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            List<SensorBeaconPair> sensorBeaconPairs = inputsString.Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Replace("Sensor at ", ""))
                .Select(x => x.Replace(" closest beacon is at ", ""))
                .Select(x => x.Split(":"))
                .Select(x => new SensorBeaconPair(new SensorBeaconPoint(x.First()), new SensorBeaconPoint(x.Last())))
                .ToList();
            SensorBeaconPoint returnPoint = new SensorBeaconPoint(0, 0);
            var allPossiblePoints = new List<SensorBeaconPoint>();
            foreach (var pair in sensorBeaconPairs)
            {
                var currentPossibilities = pair.GetAllPointsOutOfRange(MinPuzzle2, MaxPuzzle2);
                foreach (var point in currentPossibilities)
                { 
                    allPossiblePoints.Add(point);
                }
            }

            foreach (var outOfRangePoint in allPossiblePoints)
            {
                if (MinPuzzle2 > outOfRangePoint.X || outOfRangePoint.X > MaxPuzzle2) continue;
                if (MinPuzzle2 > outOfRangePoint.Y || outOfRangePoint.Y > MaxPuzzle2) continue;
                if (sensorBeaconPairs.All(pair => pair.BeaconCanBePresent(outOfRangePoint)))
                {
                    returnPoint = outOfRangePoint;
                    break;
                }
            }
            return (returnPoint.X * 4000000L + returnPoint.Y).ToString();
        }

    }

}
