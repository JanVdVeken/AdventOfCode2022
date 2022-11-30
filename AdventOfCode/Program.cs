using Common.Clients;
using Common.Services;
using Microsoft.Extensions.Configuration;

try
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddUserSecrets<AoCConfig>()
        .Build();
    var section = config.GetSection(nameof(AoCConfig));
    var aocClient = section.Get<AoCConfig>();
    IInputService inputService = await InputService.CreateInputServiceAsync(2021, aocClient);
}
catch (Exception exception)
{
    Console.WriteLine($"The following exception occured: {exception.Message}");
}
    
