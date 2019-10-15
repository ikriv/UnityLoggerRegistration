using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace UnityLoggerRegistration
{
    public class DefaultFormattersList
    {
        private readonly IUnityContainer _container;
        private readonly List<Lazy<ILogFormatter>> _deferredFormatters = new List<Lazy<ILogFormatter>>();
        private readonly Lazy<ReadOnlyCollection<ILogFormatter>> _formatters;

        public DefaultFormattersList(IUnityContainer container)
        {
            _container = container;
            _formatters = new Lazy<ReadOnlyCollection<ILogFormatter>>(() =>
                _deferredFormatters.Select(f => f.Value).ToList().AsReadOnly());
        }

        public DefaultFormattersList Add<T>(Func<T> generator) where T: ILogFormatter
        {
            if (_formatters.IsValueCreated)
            {
                throw new InvalidOperationException(
                    "Cannot add more formatters after the formatters list has been retrieved");
            }

            _deferredFormatters.Add(new Lazy<ILogFormatter>(()=>generator()));
            return this;
        }

        public DefaultFormattersList Add<T>() where T : ILogFormatter
        {
            return Add(() => _container.Resolve<T>());
        }

        public ReadOnlyCollection<ILogFormatter> FormattersList => _formatters.Value;
    }
}
