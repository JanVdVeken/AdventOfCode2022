using Common.Config;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Helpers
{
    internal class ConfigHelper
    {
        internal static IAoCConfig GetAoCConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AoCConfig>()
                .Build();
            var section = config.GetSection(nameof(AoCConfig));
            return section.Get<AoCConfig>();
        }
    }
}
