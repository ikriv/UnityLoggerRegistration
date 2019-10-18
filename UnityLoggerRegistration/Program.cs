using Unity;

namespace UnityLoggerRegistration
{
    public static class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            var container = new UnityContainer()
                .RegisterType<ILogFormatter, ParenthesisFormatter>("Parenthesis")
                .RegisterType<ILogFormatter, CurrentTimeFormatter>();

            var logger = container.Resolve<Logger>();
            logger.Log("First message");
            logger.Log("Second message");
        }
    }
}
