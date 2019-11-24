using System.Diagnostics;
using DesperateDevs.Logging;

namespace StubbFramework.Logging
{
    public static class log
    {
        [Conditional("DEBUG")]
        public static void Trace(string message)
        {
            fabl.Trace(message);
        }

        [Conditional("DEBUG")]
        public static void Debug(string message)
        {
            fabl.Debug(message);
        }

        [Conditional("DEBUG")]
        public static void Info(string message)
        {
            fabl.Info(message);
        }

        [Conditional("DEBUG")]
        public static void Warn(string message)
        {
            fabl.Warn(message);
        }

        [Conditional("DEBUG")]
        public static void Error(string message)
        {
            fabl.Error(message);
        }

        [Conditional("DEBUG")]
        public static void Fatal(string message)
        {
            fabl.Fatal(message);
        }

        [Conditional("DEBUG")]
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