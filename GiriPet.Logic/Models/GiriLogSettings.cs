using GiriPet.Logic.Enums;
using Microsoft.Extensions.Configuration;

namespace GiriPet.Logic.Models
{
    public class GiriLogSettings
    {
        private GiriLogSettings(LogLevel minLogLevel)
        {
            MinLogLevel = minLogLevel;
        }

        public static GiriLogSettings Instance { get; private set; }
        public static GiriLogSettings FromConfiguration(IConfigurationSection configurationSection)
        {
            if (Instance == null)
            {
                var minLogLevel = int.Parse(configurationSection.GetSection("MinLogLevel").Value);
                Instance = new GiriLogSettings((LogLevel)minLogLevel);
            }
            return Instance;
        }

        public LogLevel MinLogLevel { get; private set; }
    }
}
