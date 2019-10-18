using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnityLoggerRegistration
{
    internal class Logger
    {
        private readonly ObservableCollection<ILogFormatter> _formatters;

        public Logger(ObservableCollection<ILogFormatter> formatters)
        {
            _formatters = formatters;
        }

        public void Log(string message)
        {
            var formattedMessage = _formatters.Aggregate(message, (currentText, formatter) => formatter.Format(currentText));
            Console.WriteLine(formattedMessage);
        }
    }
}
