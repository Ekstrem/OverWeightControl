using System;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public class DateFilter
    {
        internal DateFilter(DateTime date, DateSeachMode mode)
        {
            Date = date;
            Mode = mode;
        }

        public DateTime Date { get; }

        public DateSeachMode Mode { get; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => Date.ToShortDateString();
    }

    public enum DateSeachMode
    {
        OnDate = 0,
        FromDate = 1,
        ToDate = 2
    }
}