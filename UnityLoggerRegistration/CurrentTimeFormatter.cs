using System;

namespace UnityLoggerRegistration
{
    internal class CurrentTimeFormatter : ILogFormatter
    {
        public string Format(string message)
        {
            return DateTime.UtcNow.ToString("HH:mm:ss.fff") + " " + message;
        }
    }
}
