using System.Transactions;

namespace AoC2022Days.DayHelpers.Day13
{
    public class FullComparer
    {
        private List<string> _dividerPackets =new() { "[[2]]", "[[6]]" };
        private List<string> _unOrganizedList;
        private List<string> _organizedList;
        public FullComparer(List<string> inputs)
        {
            inputs.AddRange(_dividerPackets);
            _unOrganizedList = inputs.Select(x => x.Trim()).ToList();
            _organizedList = new();
        }

        public int CalculateCorrectOrder()
        {
            while(_unOrganizedList.Any())
            {
                foreach(string currentLeft in _unOrganizedList)
                {
                    var isLowest = true;
                    foreach (string currentRight in _unOrganizedList.Where(x => x != currentLeft))
                    {
                        var comparer = new PairComparer(new List<string>() { currentLeft, currentRight });
                        isLowest &= comparer.CalculateOrder();
                    }
                    if(isLowest)
                    {
                        _unOrganizedList.Remove(currentLeft);
                        _organizedList.Add(currentLeft); 
                        break;
                    }
                }
            }


            return (_organizedList.IndexOf(_dividerPackets.First())+1) * (_organizedList.IndexOf(_dividerPackets.Last())+1);
        }
    }
}

