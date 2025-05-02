using GiriPet.Logic.Abstractions;
using System.Globalization;

namespace GiriPet.Logic.Services
{
    public class LocalizationService : ILocalizationService
    {
        private IReadOnlyDictionary<int, IReadOnlyDictionary<string, string>> _tranlations;

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
            langCode ??= 0;
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
