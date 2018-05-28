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
}
