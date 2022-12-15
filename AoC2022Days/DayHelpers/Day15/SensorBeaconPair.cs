namespace AoC2022Days.DayHelpers.Day15
{
    public class SensorBeaconPair
    {
        public readonly SensorBeaconPoint Beacon;
        public readonly SensorBeaconPoint Sensor;
        public int ManhattanDistance
        {
            get
            {
                return Sensor.CalcManhattanDistance(Beacon);
            }
        }
        public SensorBeaconPair(SensorBeaconPoint sensor, SensorBeaconPoint beacon)
        {
            Sensor = sensor;
            Beacon = beacon;
        }
        public bool BeaconCanBePresent(SensorBeaconPoint currentPoint)
        {
            var distanceToSensor = currentPoint.CalcManhattanDistance(Sensor);
            if (distanceToSensor <= ManhattanDistance) return false;
            return true;
        }

        public List<SensorBeaconPoint> GetAllPointsOutOfRange(int min, int max)
        {
            var returnList = new List<SensorBeaconPoint>();
            var minX = Sensor.X - ManhattanDistance - 1;
            var minY = Sensor.Y - ManhattanDistance - 1;
            var maxX = Sensor.X + ManhattanDistance + 1;
            var maxY = Sensor.Y + ManhattanDistance + 1;

            int j = 0;
            //from left corner to upper corner
            j = Sensor.Y;
            for (int i = minX; i <= Sensor.X; i++)
            {
                returnList.Add(new SensorBeaconPoint(i, j));
                j--;
            }

            //from upper corner to right corner
            j = minY;
            for (int i = Sensor.X; i <= maxX; i++)
            {
                returnList.Add(new SensorBeaconPoint(i, j));
                j++;
            }

            //from right corner to lower corner
            j = Sensor.Y;
            for (int i = maxX; i >= Sensor.X; i--)
            {
                returnList.Add(new SensorBeaconPoint(i, j));
                j++;
            }

            //from lower corner to left corner
            j = maxY;
            for (int i = Sensor.X; i >= minX; i--)
            {
                returnList.Add(new SensorBeaconPoint(i, j));
                j--;
            }
            return returnList;
        }
    }
}
