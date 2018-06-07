using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class FiltersDockControl : UserControl,
        IObserver<KeyValuePair<ColumnList,string>>,
        IObservable<IDictionary<ColumnList, string>>
    {
        private readonly IConsoleService _console;
        private IDictionary<ColumnList, string> _filters;
        private List<IObserver<IDictionary<ColumnList, string>>> _observers;

        public FiltersDockControl()
        {
            _filters = new Dictionary<ColumnList, string>();
            InitializeComponent();
            InitialControlsEvents();
        }

        [InjectionConstructor]
        public FiltersDockControl(IConsoleService console)
        {
            _console = console;
            _filters = new Dictionary<ColumnList, string>();
            InitializeComponent();
            InitialControlsEvents();
        }

        public void InitialControlsEvents()
        {
            addButton.Click += (s, e) =>
            {
                var filter = new FilterControl(_console);
                //filter.Initial(_columns);
                // _filters.Add(filter, String.Empty);
            };
        }

        public void InitColumns(ICollection<ColumnList> columns)
        {
            _filters = columns.ToDictionary(k => k, v => string.Empty);

            foreach (Control control in filtersPanel.Controls)
            {
                if (control.GetType() != typeof(FilterControl))
                    continue;
                ((FilterControl)control).Initial(_filters.Keys);
                ((FilterControl) control).Subscribe(this);
            }
        }

        /// <summary>Предоставляет наблюдателю новые данные.</summary>
        /// <param name="value">Текущие сведения об уведомлениях.</param>
        public void OnNext(KeyValuePair<ColumnList, string> value)
        {
            if (_filters.ContainsKey(value.Key))
                _filters[value.Key] = value.Value;
            else
                _filters.Add(value);
            _observers.ForEach(e => e.OnNext(_filters));
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
        public IDisposable Subscribe(IObserver<IDictionary<ColumnList, string>> observer)
        {
            if(_observers == null)
                _observers = new List<IObserver<IDictionary<ColumnList, string>>>();
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return null;
        }
    }
}
