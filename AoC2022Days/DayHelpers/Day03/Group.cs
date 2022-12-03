namespace AoC2022Days.DayHelpers.Day03;

public class Group
{
    private readonly Rucksack[] _groupContent;
    public char CommonElement;
    public Group(Rucksack r1,Rucksack r2, Rucksack r3)
    {
        _groupContent = new Rucksack[3];
        _groupContent[0] = r1;
        _groupContent[1] = r2;
        _groupContent[2] = r3;
    }

    public void CalculateCommonElement()
    {
        foreach (var element in _groupContent[0].Input.ToCharArray())
        {
            if (_groupContent[1].Input.Contains(element) && _groupContent[2].Input.Contains(element))
            {
                CommonElement = element;
            }
        }
    }

    public int GetPriority()
    {
        return Rucksack.GetPriority(CommonElement);
    }
}