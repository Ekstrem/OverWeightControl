using Newtonsoft.Json;

namespace OverWeightControl.Common.RawData
{
    /// <summary>
    /// Распознаные данные.
    /// </summary>
    [JsonObject]
    public class RecognizedValue
    {
        // Диапазон для RecognizedAccuracy
        private const double _minAccuracy = 0.0;
        private const double _maxAccuracy = 1.0;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public RecognizedValue() => RecognizedAccuracy = _maxAccuracy;

        public RecognizedValue(
            string value,
            double accuracy = _maxAccuracy)
        {
            RecognizedAccuracy = accuracy;
            Value = value;
        }

        /* Заментировано для решения2.
        /// <summary>
        /// Описание значения в акте.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Индекс чего?
        /// </summary>
        public string Index { get; set; }

        public int FieldId { get; set; } */

        /// <summary>
        /// Распознаное значение.
        /// </summary>
        [JsonProperty]
        public string Value { get; set; }

        /// <summary>
        /// Точность распознавания.
        /// </summary>
        [JsonProperty]
        public double RecognizedAccuracy { get; set; }

        /// <summary>
        /// Соответствует идеальному распознованию.
        /// Предназначено для сравнение.
        /// </summary>
        internal static double MaxAccuracy => _maxAccuracy;

        public static RecognizedValue Factory(
            string recognizeValue, double recognizedAccurancy = 1.0)
        {
            return new RecognizedValue
            {
                Value = recognizeValue,
                RecognizedAccuracy = recognizedAccurancy
            };
        }

        public override string ToString() => Value;

        public override bool Equals(object obj) => ((string)obj).Equals(Value);
    }
}
