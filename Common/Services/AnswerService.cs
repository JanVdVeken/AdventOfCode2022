using Common.AnswerCodes;
using Common.Clients;

namespace Common.Services;

public class AnswerService : IAnswerService
{
    private readonly IAocClient _client;

    public AnswerService(IAocClient aocClient)
    {
        _client = aocClient;
    }

    public async Task<GenericAnswer> PostAnswerAsync(int day,int dayPart, string answer)
    {
        var result = await _client.PostAnswerForDayAsync(day, dayPart, answer);
        if (result.Contains("You don't seem to be solving the right level."))
        {
            return new DayAlreadyCompletedAnswer($"Day {day} part {dayPart} was already completed");
        }
        if (result.Contains("You gave an answer too recently"))
        {
            return new ToSoonAnswer("Wait a long time before doing something stupid again");
        }
        if (result.ToLower().Contains("wrong"))
        {
            return new WrongAnswer($"{answer} was the wrong answer for {day} part {dayPart}");
        }
        if(result.Contains("That's the right answer!")) 
        {
            return new SuccessfulAnswer($"Successfully completed day {day} part {dayPart}");
        }
        return new GenericAnswer($"We did not found any relation between the known answers and the response we got back! {result}");
    }
}