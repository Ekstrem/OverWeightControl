using System;
using System.Collections.Generic;

namespace OverWeightControl.Core.Console
{
    public interface IConsoleService
    {
        void AddEvent(string message);
        void AddEvent(string message, ConsoleMessageType type);
        void AddEvent(string message, ConsoleMessageType type, DateTime time);
        void AddEvent(ConsoleMessage message);
        void AddException(Exception e);
        IDictionary<ConsoleMessage, bool> Flush();
    }

    public enum ConsoleMessageType
    {
        Information = 0,
        Trace = 1,
        Exception = 2
    }

    public class ConsoleMessage
    {
        public ConsoleMessage(
            string message,
            ConsoleMessageType type = ConsoleMessageType.Information)
        {
            Message = message;
            Type = type;
            Time = DateTime.Now;
        }

        public string Message { get; set; }
        public ConsoleMessageType Type { get; set; }
        public DateTime Time { get; set; }

        public override string ToString() => $"{Message} at {Time}";
    }
}
