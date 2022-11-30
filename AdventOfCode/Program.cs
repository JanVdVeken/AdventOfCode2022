using AdventOfCode.Helpers;
using Common.Clients;
using Common.Services;

var yearOfChallenge = 2021;
try
{
    var aoCConfig = ConfigHelper.GetAoCConfig();
    IAocClient client = new AocClient(aoCConfig, yearOfChallenge);
    IInputService inputService = await InputService.CreateInputServiceAsync(yearOfChallenge, client);
    IAnswerService answerService = new AnswerService(client);
    var temp = await answerService.PostAnswerAsync(19, 1, "3408");
}
catch (Exception exception)
{
    Console.WriteLine($"The following exception occured: {exception.Message}");
}
    
