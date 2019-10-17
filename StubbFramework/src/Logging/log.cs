using DesperateDevs.Logging;

namespace StubbUnity.Logging
{
    public static class log
    {
        public static void Trace(string message)
        {
            fabl.Trace(message);
        }

        public static void Debug(string message)
        {
            fabl.Debug(message);
        }

        public static void Info(string message)
        {
            fabl.Info(message);
        }

        public static void Warn(string message)
        {
            fabl.Warn(message);
        }

        public static void Error(string message)
        {
            fabl.Error(message);
        }

        public static void Fatal(string message)
        {
            fabl.Fatal(message);
        }

        public static void Assert(bool condition, string message)
        {
            fabl.Assert(condition, message);
        }

        public static void AddAppender(LogDelegate appender)
        {
            fabl.AddAppender(appender);
        }
    }
}