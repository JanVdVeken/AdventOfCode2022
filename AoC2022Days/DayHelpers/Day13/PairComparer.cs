using System.ComponentModel;
using System.Text.Json.Nodes;

namespace AoC2022Days.DayHelpers.Day13
{
    public class PairComparer
    {
        private string _left;
        private string _right;
        public PairComparer(List<string> inputs)
        {
            _left = inputs.Where(x => !string.IsNullOrEmpty(x)).First();
            _right = inputs.Where(x => !string.IsNullOrEmpty(x)).Last();
        }

        public bool CalculateOrder()
        {
            return CalculateOrderRecusive(JsonNode.Parse(_left), JsonNode.Parse(_right)) < 0;
        }

        private int CalculateOrderRecusive(JsonNode left, JsonNode right)
        {
            if (left is JsonValue && right is JsonValue)
            {
                return (int)left - (int)right;
            }
            var leftArray = left is JsonArray ? left as JsonArray: new JsonArray((int)left);
            var rightArray = right is JsonArray ? right as JsonArray : new JsonArray((int)right);
            var combined = Enumerable.Zip(leftArray, rightArray);
            foreach(var pair in combined)
            {
                var result = CalculateOrderRecusive(pair.First, pair.Second);
                if (result != 0) return result;
            }
            return leftArray.Count - rightArray.Count;
        }
    }
}
