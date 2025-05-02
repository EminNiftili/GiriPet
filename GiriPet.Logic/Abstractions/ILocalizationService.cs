namespace GiriPet.Logic.Abstractions
{
    public interface ILocalizationService
    {
        IReadOnlyDictionary<string, string>? GetLocalization(int langCode);
        void LoadIfNecessary();
        string Translate(string key, int? langCode = null);
        string Translate(string key, string defaultValue, int? langCode = null);

    }
}
