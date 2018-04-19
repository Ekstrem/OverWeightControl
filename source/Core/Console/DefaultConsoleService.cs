using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OverWeightControl.Core.Console
{
    public class DefaultConsoleService : IConsoleService
    {
        /// <summary>
        /// bool значение - новое и непрочитано.
        /// </summary>
        protected IDictionary<ConsoleMessage, bool> _log;

        public DefaultConsoleService()
        {
            _log = new ConcurrentDictionary<ConsoleMessage, bool>();
        }

        public void AddEvent(string message)
        {
            AddEvent(new ConsoleMessage(message));
        }

        public void AddEvent(string message, ConsoleMessageType type)
        {
            AddEvent(new ConsoleMessage(message, type));
        }

        public void AddEvent(string message, ConsoleMessageType type, DateTime time)
        {
            var cm = new ConsoleMessage(message, type) { Time = time };
            AddEvent(cm);
        }

        public void AddEvent(ConsoleMessage message)
        {
            _log.Add(message, true);
        }

        public void AddException(Exception e)
        {
            AddEvent(
                message: $"{e.Message}\n{e?.InnerException?.Message ?? string.Empty}",
                type: ConsoleMessageType.Exception);

        }

        public virtual IDictionary<ConsoleMessage, bool> Flush()
        {
            foreach (var message in _log.Keys.Where(f=> _log[f]))
            {
                string clipMessage =
                    $"At {message.Time.ToShortTimeString()} event {((int)message.Type)}, message: {message.Message}";
                _log[message] = false;
                System.Console.WriteLine(clipMessage);
            }

            
            System.Console.ReadKey();
            return _log;
        }
    }
}
