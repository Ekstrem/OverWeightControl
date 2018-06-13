using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OverWeightControl.Core.Console;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class FiltersDockControl : UserControl,
        IObserver<KeyValuePair<ColumnList, SearchingTerm>>,
        IObservable<IDictionary<ColumnList, SearchingTerm>>,
        IObservable<IList<DateFilter>>
    {
        private readonly IConsoleService _console;
        private IDictionary<ColumnList, SearchingTerm> _filters;
        private List<IObserver<IDictionary<ColumnList, SearchingTerm>>> _filtersObservers;
        private IDictionary<DateSeachMode, DateFilter> _datesFilters;
        private List<IObserver<IList<DateFilter>>> _datesFiltersObservers;

        public FiltersDockControl()
        {
            _filters = new Dictionary<ColumnList, SearchingTerm>();
            _datesFilters = new Dictionary<DateSeachMode, DateFilter>();
            InitializeComponent();
            InitialControlsEvents();
        }

        [InjectionConstructor]
        public FiltersDockControl(IConsoleService console)
        {
            _console = console;
            _filters = new Dictionary<ColumnList, SearchingTerm>();
            _datesFilters = new Dictionary<DateSeachMode, DateFilter>();
            InitializeComponent();
            InitialControlsEvents();
        }

        public void InitialControlsEvents()
        {
            addButton.Click += (s, e) =>
            {
                try
                {
                    var filter = new FilterControl(_console);
                    filter.Initial(_filters.Keys);
                    int count = filtersPanel.Controls.Count-4;
                    filter.Location = new Point(0, count * 30);
                    filter.Parent = filtersPanel;
                    filter.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
                    filter.Size = new Size(filtersPanel.Width - 7, 29);
                    filter.Subscribe(this);
                    filtersPanel.Controls.Add(filter);
                }
                catch (Exception exception)
                {
                    _console?.AddException(exception);
                }
            };
            removeButton.Click += (s, e) =>
            {
                try
                {
                    for (int i = filtersPanel.Controls.Count - 1; i >= 0; i--)
                    {
                        if (filtersPanel.Controls[i] is FilterControl)
                            filtersPanel.Controls[i].Dispose();
                    }

                    _filters.Keys.ForEach(i => _filters[i] = new SearchingTerm(String.Empty));
                }
                catch (Exception exception)
                {
                    _console?.AddException(exception);
                }
            };
            fromCheckBox.CheckedChanged += (s, e) =>
            {
                bool result = fromCheckBox.Checked;
                fromDateTimePicker.Enabled = result;
                if (!result)
                {
                    if (toCheckBox.Checked)
                    {
                        toCheckBox.Checked = false;
                        toDateTimePicker.Enabled = false;
                    }

                    _datesFilters.Clear();
                }
                else
                {
                    if (!_datesFilters.ContainsKey(DateSeachMode.OnDate))
                        _datesFilters.Add(DateSeachMode.OnDate, new DateFilter(fromDateTimePicker.Value, DateSeachMode.OnDate));
                }

                _datesFiltersObservers.ForEach(i => i.OnNext(_datesFilters.Values.ToList()));
            };
            toCheckBox.CheckedChanged += (s, e) =>
            {
                if (!fromCheckBox.Checked)
                {
                    if (toCheckBox.Checked)
                        ((CheckBox) s).CheckState = CheckState.Unchecked;
                    if (_datesFilters.ContainsKey(DateSeachMode.FromDate))
                        _datesFilters.Remove(DateSeachMode.FromDate);
                    if (_datesFilters.ContainsKey(DateSeachMode.ToDate))
                        _datesFilters.Remove(DateSeachMode.ToDate);
                    return;
                }

                toDateTimePicker.Enabled = toCheckBox.Checked;
                fromCheckBox.Text = toCheckBox.Checked ? "C" : "На";

                if (!_datesFilters.ContainsKey(DateSeachMode.FromDate))
                    _datesFilters.Add(DateSeachMode.FromDate, null);
                _datesFilters[DateSeachMode.FromDate] = new DateFilter(
                    fromDateTimePicker.Value, DateSeachMode.FromDate);

                if (!_datesFilters.ContainsKey(DateSeachMode.ToDate))
                    _datesFilters.Add(DateSeachMode.ToDate, null);
                _datesFilters[DateSeachMode.ToDate] = new DateFilter(
                    toDateTimePicker.Value, DateSeachMode.ToDate);

                _datesFiltersObservers.ForEach(i => i.OnNext(_datesFilters.Values.ToList()));
            };
            fromDateTimePicker.ValueChanged += (s, e) =>
            {
                DateSeachMode mode = toCheckBox.Checked
                    ? DateSeachMode.FromDate
                    : DateSeachMode.OnDate;
                if (!_datesFilters.ContainsKey(mode))
                    _datesFilters.Add(mode, null);
                _datesFilters[mode] = new DateFilter(
                    fromDateTimePicker.Value, mode);
                _datesFiltersObservers.ForEach(i => i.OnNext(_datesFilters.Values.ToList()));
            };
            toDateTimePicker.ValueChanged += (s, e) =>
            {
                var mode = DateSeachMode.ToDate;
                _datesFilters[mode] = new DateFilter(
                    toDateTimePicker.Value, mode);
                _datesFiltersObservers.ForEach(i => i.OnNext(_datesFilters.Values.ToList()));
            };
        }

        public void InitColumns(ICollection<ColumnList> columns)
        {
            try
            {
                _filters = columns.ToDictionary(k => k, v => new SearchingTerm(String.Empty));

                foreach (Control control in filtersPanel.Controls)
                {
                    if (control.GetType() != typeof(FilterControl))
                        continue;
                    ((FilterControl) control).Initial(_filters.Keys);
                    ((FilterControl) control).Subscribe(this);
                }
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
        }

        /// <summary>Предоставляет наблюдателю новые данные.</summary>
        /// <param name="value">Текущие сведения об уведомлениях.</param>
        public void OnNext(KeyValuePair<ColumnList, SearchingTerm> value)
        {
            try
            {
                if (_filters.ContainsKey(value.Key))
                    _filters[value.Key] = value.Value;
                else
                    _filters.Add(value);
                _filtersObservers.ForEach(e => e.OnNext(_filters));
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }

        /// <summary>
        ///   Уведомляет наблюдателя о том, что у поставщика возникла ошибка.
        /// </summary>
        /// <param name="error">
        ///   Объект, который предоставляет дополнительную информацию об ошибке.
        /// </param>
        public void OnError(Exception error)
        {
            _console?.AddException(error);
        }

        /// <summary>
        ///   Уведомляет наблюдателя о том, что поставщик завершил отправку push-уведомлений.
        /// </summary>
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Уведомляет поставщика о том, что наблюдатель должен получать уведомления.
        /// </summary>
        /// <param name="observer">
        ///   Объект, который должен получать уведомления.
        /// </param>
        /// <returns>
        ///   Ссылка на интерфейс, позволяющий наблюдателям прекратить получение уведомлений до того, как поставщик завершит их отправку.
        /// </returns>
        IDisposable IObservable<IDictionary<ColumnList, SearchingTerm>>.Subscribe(IObserver<IDictionary<ColumnList, SearchingTerm>> observer)
        {
            if(_filtersObservers == null)
                _filtersObservers = new List<IObserver<IDictionary<ColumnList, SearchingTerm>>>();
            if (!_filtersObservers.Contains(observer))
                _filtersObservers.Add(observer);
            return null;
        }

        /// <summary>
        ///   Уведомляет поставщика о том, что наблюдатель должен получать уведомления.
        /// </summary>
        /// <param name="observer">
        ///   Объект, который должен получать уведомления.
        /// </param>
        /// <returns>
        ///   Ссылка на интерфейс, позволяющий наблюдателям прекратить получение уведомлений до того, как поставщик завершит их отправку.
        /// </returns>
        IDisposable IObservable<IList<DateFilter>>.Subscribe(IObserver<IList<DateFilter>> observer)
        {
            if (_datesFiltersObservers == null)
                _datesFiltersObservers = new List<IObserver<IList<DateFilter>>>();
            if (!_datesFiltersObservers.Contains(observer))
                _datesFiltersObservers.Add(observer);
            return null;
        }
    }
}
