namespace AoC2022Days.DayHelpers.Day05
{
    public class Ship
    {
        public List<List<char>> Stacks;
        public Ship(List<string> inputs)
        {
            var stackNumbers = inputs.Last();
            var amountOfStacks = int.Parse(stackNumbers.Trim().Split("   ").Last());
            Stacks = new List<List<char>>();
            for (int i = 0; i < amountOfStacks; i++) { Stacks.Add(new List<char>()); }
            var uselessChars = "[] ";
            foreach (var input in inputs.SkipLast(1))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    var inputchar = input[i];
                    if (uselessChars.Contains(inputchar)) continue;
                    var stackindex = int.Parse(stackNumbers.Substring(i, 1)) - 1;
                    Stacks[stackindex].Add(inputchar);
                }
            }
        }

        public void MoveCrateMover9000(Procedure procedure)
        {
            for (int i = 0; i < procedure.Times; i++)
            {
                Stacks[procedure.To - 1].Insert(0, Stacks[procedure.From - 1][0]);
                Stacks[procedure.From - 1].RemoveAt(0);
            }
        }
        public void MoveCrateMover9001(Procedure procedure)
        {
            for (int i = 0; i < procedure.Times; i++)
            {
                Stacks[procedure.To - 1].Insert(0+i, Stacks[procedure.From - 1][0]);
                Stacks[procedure.From - 1].RemoveAt(0);
            }
        }

        public string GetTopOfStacks()
        {
            var returnValue = "";
            Stacks.ForEach(x => returnValue += x[0]);
            return returnValue;
        }
    }
}
