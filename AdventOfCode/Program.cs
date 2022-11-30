using AdventOfCode.Helpers;
using Common.Clients;
using Common.Services;

int yearOfChallenge = 2021;
try
{
    var aoCConfig = ConfigHelper.GetAoCConfig();
    IAocClient _client = new AocClient(aoCConfig, yearOfChallenge);
    IInputService inputService = await InputService.CreateInputServiceAsync(yearOfChallenge, _client);
}
catch (Exception exception)
{
    Console.WriteLine($"The following exception occured: {exception.Message}");
}
    
