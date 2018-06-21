using System.Collections.Generic;

namespace OverWeightControl.Clients.ActsUI.Tools
{
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
}