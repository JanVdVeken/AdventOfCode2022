using System.Runtime.CompilerServices;

namespace AoC2022Days.DayHelpers.Day03;

public class Rucksack
{
    private const string prio = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public readonly string FirstCompartement;
    public readonly string SecondCompartement;
    public char CommonElement;
    public readonly string Input;
    public Rucksack(string input)
    {
        Input = input;
        FirstCompartement = input.Substring(0, input.Length / 2);
        SecondCompartement = input.Substring(input.Length / 2);
    }

    public void CalculateCommonElement()
    {
        foreach (var element in FirstCompartement)
        {
            if (SecondCompartement.Contains(element)) CommonElement = element;
        }
    }

    public int GetPriority()
    {
        return prio.IndexOf(CommonElement)+1;
    }

    public static int GetPriority(char element)
    {
        return prio.IndexOf(element)+1;

    }
}