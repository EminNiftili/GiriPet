using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Models;
using Microsoft.Extensions.Logging;

namespace GiriPet.Logic.Services
{
    public class GiriLogger : IGiriLogger
    {
        private readonly GiriLogSettings _settings;
        private readonly IFileService _fileService;

        public GiriLogger(IFileService fileService)
        {
            this._fileService = fileService;
            _settings = GiriLogSettings.Instance;
        }

        public void Log(string message, Enums.LogLevel level)
             => Log(new GiriLog(level, [message], null));

        public void Log(Exception exception, Enums.LogLevel level)
            => Log(new GiriLog(level, [], exception));

        private void Log(GiriLog log)
        {
            if(log.Level == Enums.LogLevel.Error)
            {

            }
            var message = log.ToString();
            string filePath = $"{DateTime.Now.ToString("dd-MM-yyyy")}_{log.Level.ToString()}";
            var appDirectory = Directory.GetCurrentDirectory();
            var fullDirectory = $"{appDirectory}\\log\\{filePath}";
            _fileService.AppendText(fullDirectory, filePath, message);
        }
    }
}
