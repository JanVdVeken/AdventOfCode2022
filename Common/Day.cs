using Common.AnswerCodes;
using Common.Services;
using System.Diagnostics;

namespace Common;

public abstract class Day
{
    public readonly string Title;
    public readonly int DayNumber;
    private readonly IInputService _inputService;
    private readonly IAnswerService _answerService;
    private IEnumerable<string> _input;

    public Day(IInputService inputService, IAnswerService answerService, int dayNumber, string dayTitle)
    {
        _inputService = inputService;
        _answerService = answerService;
        Title = dayTitle;
        DayNumber = dayNumber;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{DayNumber}. {Title}");
    }

    public async Task HandleSelect()
    {
        Console.WriteLine("Do you want to solve Part 1(S) or 2(S) or P (both with Performance)?");
        var answer = "";
        switch (Console.ReadLine())
        {
            case "1":
                answer = Puzzle1(await GatherInputAsync());
                break;
            case "1S":
                answer = (await PostAnswer1Async()).InternalMessage;
                break;
            case "2":
                answer = Puzzle2(await GatherInputAsync());
                break;
            case "2S":
                answer = (await PostAnswer2Async()).InternalMessage;
                break;
            case "P":
                LogPerformaceBothPartsAsync();
                break;
            default:
                Console.WriteLine($"Not implemented");
                await HandleSelect();
                break;
        }

        Console.WriteLine(answer);
    }

    public void Deselect()
    {
        Console.WriteLine("Press Key to go back to main menu");
        Console.ReadKey();
        Console.Clear();
    }

    public async Task<IEnumerable<string>> GatherInputAsync()
    {
        if (_input is null)
        {
            _input = (await _inputService.GetInputOfDayAsync(DayNumber)).Split("\n");
        }

        return _input;
    }

    public abstract string Puzzle1(IEnumerable<string> inputsString);

    public abstract string Puzzle2(IEnumerable<string> inputsString);

    public async Task<GenericAnswer> PostAnswer1Async()
    {
        var answer = Puzzle1(await GatherInputAsync());
        Console.WriteLine($"Posting {answer} to api...");
        return await _answerService.PostAnswerAsync(DayNumber, 1, answer);
    }

    public async Task<GenericAnswer> PostAnswer2Async()
    {
        var answer = Puzzle2(await GatherInputAsync());
        Console.WriteLine($"Posting {answer} to api...");
        return await _answerService.PostAnswerAsync(DayNumber, 2, answer);
    }
    private async void LogPerformaceBothPartsAsync()
    {
        await GatherInputAsync();
        Stopwatch stopwatch = new();
        Dictionary<string, double> timings_per_action = new();
        Console.WriteLine($"Getting metrics for day {DayNumber}...");
        stopwatch.Reset();
        stopwatch.Start();
        var p1Result = Puzzle1(_input);
        stopwatch.Stop();
        Console.WriteLine($"Puzzle 1) {(double)stopwatch.ElapsedTicks / TimeSpan.TicksPerMillisecond}ms \t=> {p1Result}");
        stopwatch.Reset();
        stopwatch.Start();
        var p2Result = Puzzle2(_input);
        stopwatch.Stop();
        Console.WriteLine($"Puzzle 2) {(double)stopwatch.ElapsedTicks / TimeSpan.TicksPerMillisecond}ms \t=> {p2Result}");
    }
}