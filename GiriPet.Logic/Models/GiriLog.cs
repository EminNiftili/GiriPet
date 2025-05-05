using GiriPet.Logic.Enums;
using System.Diagnostics.Metrics;

namespace GiriPet.Logic.Models
{
    public class GiriLog
    {
        private string _finalText;
        public GiriLog(LogLevel level, string[] parameters, Exception? exception)
        {
            Level = level;
            Parameters = parameters;
            Exception = exception;
            _finalText = string.Empty;
        }

        public LogLevel Level { get; }
        public string[] Parameters { get; }
        public Exception? Exception { get; }

        public override string ToString()
        {
            _finalText = string.Empty;

            _finalText += DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:FFFFFFF");
            _finalText = TextSeperator(_finalText);
            _finalText += $"LogLevel: {Level.ToString()}";
            _finalText = TextSeperator(_finalText);
            if (this.Parameters != null && this.Parameters.Count() > 0)
            {
                _finalText += string.Join(" ", Parameters);
                _finalText = TextSeperator(_finalText);
            }
            if(Exception != null)
            {
                _finalText += GetMessageFromException(Exception);
                _finalText = TextSeperator(_finalText);
            }
            return _finalText;
        }

        private string TextSeperator(string text)
        {
            text += "\n";
            return text;
        }
        private string GetMessageFromException(Exception exception)
        {
            string message = string.Empty;
            do
            {
                message += exception.Message;
                message += TextSeperator(message);
                exception = exception.InnerException;
            }while (exception != null);
            return message;
        }
    }
}
