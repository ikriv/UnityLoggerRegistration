namespace UnityLoggerRegistration
{
    internal class ParenthesisFormatter : ILogFormatter
    {
        public string Format(string message)
        {
            return "(" + message + ")";
        }
    }
}
