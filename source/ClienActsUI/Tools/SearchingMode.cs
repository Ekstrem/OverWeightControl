using System;
using System.Collections.Generic;

namespace OverWeightControl.Clients.ActsUI.Tools
{
    public class SearchingMode
    {
        public SearchingMode(SearchingModeEnum mode)
        {
            Mode = mode;
        }

        public SearchingModeEnum Mode { get; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString()
        {
            switch (Mode)
            {
                case SearchingModeEnum.StartsWith:
                    return "Начинается с";
                case SearchingModeEnum.Contains:
                    return "Содержит";
                default:
                    return String.Empty;
            }
        }

        public static ICollection<SearchingMode> GetModes()
        {
            //var t = typeof(SearchingModeEnum).GetFields()
            //    .Where(f => f.FieldType == typeof(SearchingModeEnum))
            //    .Select(m => m.Name);
            return new List<SearchingMode>
            {
                new SearchingMode(SearchingModeEnum.StartsWith),
                new SearchingMode(SearchingModeEnum.Contains)
            };
        }

        /// <summary>
        ///   Определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="obj">
        ///   Объект, который требуется сравнить с текущим объектом.
        /// </param>
        /// <returns>
        ///   Значение <see langword="true" />, если указанный объект равен текущему объекту; в противном случае — значение <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj != null && obj is SearchingMode && Mode.Equals(((SearchingMode)obj).Mode);
        }

        public override int GetHashCode()
        {
            return 851357954 + Mode.GetHashCode();
        }

        public static implicit operator int(SearchingMode mode) => (int) mode.Mode;
        public static implicit operator SearchingModeEnum(SearchingMode mode) => mode.Mode;
    }
}