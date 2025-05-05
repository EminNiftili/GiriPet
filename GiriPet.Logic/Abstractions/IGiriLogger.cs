using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Abstractions
{
    public interface IGiriLogger
    {
        void Log(string message, LogLevel level);
        void Log(Exception exception, LogLevel level);
    }
}
