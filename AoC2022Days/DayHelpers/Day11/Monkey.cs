using System.Data;
using System.Reflection.PortableExecutable;

namespace AoC2022Days.DayHelpers.Day11;

public class Monkey
{
    public readonly int Id;
    public long InspectionsCounter;
        
    private List<long> _items;
    private readonly char _operator;
    private readonly string _operant;
    public readonly int Tester;
    private readonly int _trueMonkey;
    private readonly int _falseMonkey;
    
    public Monkey(List<string> inputs)
    {
        _items = new List<long>();
        Id = int.Parse(inputs.First().Trim().Replace("Monkey ","").Replace(":",""));
        _items = inputs[1].Replace("Starting items: ", "")
            .Split(",")
            .Select(x => long.Parse(x.Trim()))
            .ToList();
        _operator = inputs[2].Trim().Replace("Operation: new = old ","")
            .Split(" ")
            .First()
            .Trim().ToCharArray()[0];
        _operant = inputs[2].Trim().Replace("Operation: new = old ","")
            .Split(" ").Last();
        Tester = int.Parse(inputs[3].Trim().Replace("Test: divisible by ", "").Trim());
        _trueMonkey =int.Parse(inputs[4].Trim().Replace("If true: throw to monkey ", "").Trim());
        _falseMonkey =int.Parse(inputs[5].Trim().Replace("If false: throw to monkey ", "").Trim());
    }

    public void CalculateRound(List<Monkey> monkeys, int div)
    {
        foreach (var item in _items)
        {
            var newItem = AdaptWorryLevel(item,div);
            if (newItem % Tester == 0)
            {
                monkeys.Single(x => x.Id == _trueMonkey).AddToItems(newItem);
            }
            else
            {
                monkeys.Single(x => x.Id == _falseMonkey).AddToItems(newItem);
            }

            InspectionsCounter++;
        }
        _items = new List<long>();
    }

    private long AdaptWorryLevel(long item,int div)
    {
        var currentOperant = item;
        if (long.TryParse(_operant, out long temp)) currentOperant = temp;
        if (_commonDenominator != 0) item %= _commonDenominator;
        return _operator switch
        {
            '*' => (item * currentOperant) / div,
            '+' => (item + currentOperant) / div,
            _ => 0
        };
    }

    public void AddToItems(long item)
    {
        _items.Add(item);
    }

    private int _commonDenominator;
    public void SetCommonDenominator(int commonDenominator)
    {
        _commonDenominator = commonDenominator;
    }
}