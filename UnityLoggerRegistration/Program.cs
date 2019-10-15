using Unity;
using Unity.Lifetime;


namespace UnityLoggerRegistration
{
    public static class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container
                .RegisterType<DefaultFormattersList>(new ContainerControlledLifetimeManager())
                .RegisterFactory<ILogger>(c =>
                    new LoggerWithFormatters(c.Resolve<ConsoleLogger>(),
                        c.Resolve<DefaultFormattersList>().FormattersList));

            container.Resolve<DefaultFormattersList>()
                .Add<ParenthesisFormatter>()
                .Add<CurrentTimeFormatter>();

            var logger = container.Resolve<ILogger>();
            logger.Log("First message");
            logger.Log("Second message");
        }
    }
}
