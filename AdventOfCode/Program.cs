using Common.Services;

try
{
    IInputService inputService = await InputService.CreateInputServiceAsync(2021);
}
catch(Exception exception)
{
    Console.WriteLine($"The following exception occured: {exception.Message}");
}