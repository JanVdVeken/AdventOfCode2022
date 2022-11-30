﻿using Common.AnswerCodes;
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
            return new ToSoonAnswer("Wait some a long time before doing something stupid again");
        }
        if (result.Contains("wrong"))
        {
            return new WrongAnswer($"{answer} was the wrong answer for {day} part {dayPart}");
        }
        return new SuccessfulAnswer($"Successfully completed day {day} part {dayPart}");
    }
}