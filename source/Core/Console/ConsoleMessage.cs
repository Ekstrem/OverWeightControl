using System;
using Newtonsoft.Json;

namespace OverWeightControl.Core.Console
{
    [JsonObject]
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

        [JsonProperty]
        public string Message { get; set; }
        [JsonProperty]
        public ConsoleMessageType Type { get; set; }
        [JsonProperty]
        public DateTime Time { get; set; }

        public override string ToString() => $"{Message} at {Time}";
    }
}