using Common.Services;

try
{
    IInputService inputService = new InputService(2021);
    var temp = await inputService.GetInputOfDayAsync(10);
    
}
catch(Exception exception)
{
    Console.WriteLine($"The following exception occured: {exception.Message}");
}