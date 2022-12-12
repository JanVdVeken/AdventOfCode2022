namespace AoC2022Days.DayHelpers.Day12
{
    public class HeightPoint
    {
        private const string Alphabet = "SabcdefghijklmnopqrstuvwxyzE";
        public readonly int X;
        public readonly int Y;
        public readonly int Height;

        private int _distanceFromStart;
        public int DistanceFromStart { get => _distanceFromStart;}

        public HeightPoint(int x, int y, char charHeight)
        {
            X= x;
            Y= y;
            Height = Alphabet.IndexOf(charHeight);
            _distanceFromStart = 5000;
        }

        public bool Equals(HeightPoint other)
        {
            return other.X == X && other.Y == Y;
        }

        public char GetCharValue()
        {
            switch (Height)
            {
                case 0: return 'S';
                case 27: return 'E';
                default: return Alphabet[Height];
            }
        }

        public bool UpdateDistanceFromStart(int value)
        {
             var temp = Math.Min(_distanceFromStart, value);
            if (temp == _distanceFromStart) return false;
            _distanceFromStart = temp;
            return true;
        }
        public void ResetDistanceFromStart()
        {
            _distanceFromStart = 5000;
        }

    }
}
