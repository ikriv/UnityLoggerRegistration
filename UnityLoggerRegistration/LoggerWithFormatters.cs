using System.Collections.Generic;
using System.Linq;

namespace UnityLoggerRegistration
{
    internal class LoggerWithFormatters : ILogger
    {
        private readonly ILogger _upstream;
        private readonly IReadOnlyCollection<ILogFormatter> _formatters;

        public LoggerWithFormatters(ILogger upstream, IReadOnlyCollection<ILogFormatter> formatters)
        {
            _upstream = upstream;
            _formatters = formatters;
        }

        public void Log(string message)
        {
            var formattedMessage = _formatters.Aggregate(message, (currentText, formatter) => formatter.Format(currentText));
            _upstream.Log(formattedMessage);
        }
    }
}
