namespace AoC2022Days.DayHelpers.Day08
{
    public class Tree
    {
        private readonly int _row;
        private readonly int _col;
        private readonly int _height;
        private bool _isVisible;
        public Tree(int row, int col, int height, bool isVisible)
        {
            _row = row;
            _col = col;
            _height = height;
            _isVisible= isVisible;
        }
        public void SetVisibility(bool visibility)
        {
            _isVisible = visibility;
        }

        public bool IsVisible => _isVisible;
        public int Height => _height;
        public int Row => _row;
        public int Col => _col;
    }
}
