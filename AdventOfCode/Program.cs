using AdventOfCode.Helpers;
using AoC2022Days;
using AoC2022Days.Days;
using Common;
using Common.Clients;
using Common.Services;

var yearOfChallenge = 2022;
try
{
    IAocClient client = new AocClient(ConfigHelper.GetAoCConfig(), yearOfChallenge);
    IInputService inputService = await InputService.CreateInputServiceAsync(yearOfChallenge, client);
    IAnswerService answerService = new AnswerService(client);
    List<Day> Days = new()
    {
        new Day01(inputService,answerService,1,"Calorie Counting"),
        new Day02(inputService,answerService,2,"Rock Paper Scissors"),
        new Day03(inputService,answerService,3,"Rucksack Reorganization"),
        new Day04(inputService,answerService,4,"Camp Cleanup"),
        new Day05(inputService,answerService,5,"Supply Stacks"),
        new Day06(inputService,answerService,6,"Tuning Trouble"),
        new Day07(inputService,answerService,7,"No Space Left On Device"),
        new Day08(inputService,answerService,8,"Treetop Tree House"),
        new Day09(inputService,answerService,9,"Rope Bridge"),
        new Day10(inputService,answerService,10,"Cathode-Ray Tube"),
        new Day11(inputService,answerService,11,"Monkey in the Middle"),
        new Day12(inputService,answerService,12,"Hill Climbing Algorithm"),
        new Day13(inputService,answerService,13,"Distress Signal"),
        new Day14(inputService,answerService,14,"Regolith Reservoir"),
        new Day15(inputService,answerService,15,"Beacon Exclusion Zone"),
        new Day16(inputService,answerService,16,"Proboscidea Volcanium"),
        
        new Day18(inputService,answerService,18,"Boiling Boulders"),


        new Day21(inputService,answerService,21,"Monkey Math"),
    };
    Console.Title = $"Advent Of Code {yearOfChallenge}";
    while (true)
    {
        Console.WriteLine("Which Day do you want ?");
        Days.Where(x => x.Title != null).ToList().ForEach(x => x.PrintInfo());
        var input = Console.ReadLine();
        if (input.ToLower() == "exit")
        {
            break;
        }
        if (int.TryParse(input, out var chosenDay) && Days.SingleOrDefault(x => x.DayNumber == chosenDay) != null)
        {
            var day = Days.Single(x => x.DayNumber == chosenDay);
            await day.HandleSelect();
            day.Deselect();
        }
        else
        {
            Console.WriteLine("Day not found, Press Key to go back to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
catch (Exception exception)
{
    Console.WriteLine($"The following exception occured: {exception.Message}");
}
    
