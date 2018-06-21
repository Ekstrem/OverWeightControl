using System;
using System.Collections.Generic;
using System.Linq;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public class ColumnInfo
    {
        public string Name { get; set; }
        public int Num { get; set; }
        public bool Visible { get; set; }
        public string Description { get; set; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => Name;
    }

    public class SearchingTerm
    {
        public SearchingTerm(string data, SearchingMode mode = null)
        {
            SearchingData = data;
            Mode = mode ?? new SearchingMode(SearchingModeEnum.Contains);
        }

        public string SearchingData { get; set; }
        public SearchingMode Mode { get; set; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => SearchingData;

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
            var eq = (SearchingTerm) obj;
            return Mode.Equals(eq.Mode) && SearchingData.Equals(eq.SearchingData);
        }

        public override int GetHashCode()
        {
            var hashCode = -1521891127;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SearchingData);
            hashCode = hashCode * -1521134295 + EqualityComparer<SearchingMode>.Default.GetHashCode(Mode);
            return hashCode;
        }
    }

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

    public enum SearchingModeEnum
    {
        StartsWith = 0,
        Contains = 1
    }
}