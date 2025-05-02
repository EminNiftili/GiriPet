using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Models;

namespace GiriPet.Logic.Services
{
    public class LocalizationService : ILocalizationService
    {
        private IReadOnlyDictionary<int, IReadOnlyDictionary<string, string>> _tranlations;
        private readonly LocalizationSettings _settings;

        public LocalizationService(LocalizationSettings settings)
        {
            _settings = settings;
        }

        public IReadOnlyDictionary<string, string>? GetLocalization(int langCode)
        {
            LoadIfNecessary();
            if(_tranlations != null && _tranlations.TryGetValue(langCode, out var translationByLang))
            {
                return translationByLang;
            }
            return null;
        }

        public void LoadIfNecessary()
        {
            if(_tranlations == null)
            {
                return;
            }
        }

        public string Translate(string key, int? langCode = null) => Translate(key, key, langCode);

        public string Translate(string key, string defaultValue, int? langCode = null)
        {
            langCode ??= _settings.DefaultLangId;
            return GetText(key, langCode.Value) ?? defaultValue;
        }

        private string? GetText(string key, int langCode)
        {
            var translations = GetLocalization(langCode);
            if(translations != null && translations.TryGetValue(key, out var text))
            {
                return text;
            }
            return null;
        }
    }
}
