using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Models;
using Microsoft.Extensions.Logging;

namespace GiriPet.Logic.Services
{
    public class GiriLogger : IGiriLogger
    {
        public void Log(string message, Enums.LogLevel level)
             => Log(new GiriLog(level, [message], null));

        public void Log(Exception exception, Enums.LogLevel level)
            => Log(new GiriLog(level, [], exception));

        private void Log(GiriLog log)
        {

        }
    }
}
