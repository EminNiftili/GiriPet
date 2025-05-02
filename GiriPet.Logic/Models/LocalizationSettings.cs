using GiriPet.Logic.Services;
using Microsoft.Extensions.Configuration;

namespace GiriPet.Logic.Models
{
    public class LocalizationSettings
    {
        public static LocalizationSettings Instance { get; private set; }
        private LocalizationSettings(int defaultLangId)
        {
            DefaultLangId = defaultLangId;
        }

        public static LocalizationSettings FromConfiguration(IConfigurationSection configurationSection)
        {
            if(Instance == null)
            {
                var defaultLangCodeId = int.Parse(configurationSection.GetSection("DefaultLangCodeId").Value);
                Instance = new LocalizationSettings(defaultLangCodeId);
            }
            return Instance;
        }

        public int DefaultLangId { get; }
    }
}
