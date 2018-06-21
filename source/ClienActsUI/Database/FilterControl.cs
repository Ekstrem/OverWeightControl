using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unity.Attributes;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class FilterControl : 
        UserControl,
        IObservable<KeyValuePair<ColumnInfo, SearchingTerm>>
    {
        private readonly IConsoleService _console;
        private List<IObserver<KeyValuePair<ColumnInfo, SearchingTerm>>> _observers;
        private ColumnInfo _priviousColumn;

        public FilterControl()
        {
            InitializeComponent();
            InitialComponentsEvents();
        }

        [InjectionConstructor]
        public FilterControl(
            IConsoleService console)
        {
            _console = console;

            InitializeComponent();

            InitialComponentsEvents();

            console?.AddEvent($"{nameof(FilterControl)} created.");
        }

        private void InitialComponentsEvents()
        {
            textBox.TextChanged += (s, e) =>
            {
                try
                {
                    if (!checkBox1.Checked)
                        return;

                    _priviousColumn = (ColumnInfo) comboBox.SelectedItem;
                    var pair = new KeyValuePair<ColumnInfo, SearchingTerm>(
                        (ColumnInfo)comboBox.SelectedItem,
                        new SearchingTerm(((TextBox)s).Text, (SearchingMode)comboBox1.SelectedItem)
                        );
                    _observers?.ForEach(en => en.OnNext(pair));
                }
                catch (Exception exception)
                {
                    _console?.AddException(exception);
                }
            };
            
            checkBox1.CheckedChanged += (s, e) =>
            {
                try
                {
                    comboBox.Enabled = checkBox1.Checked;
                    textBox.Enabled = checkBox1.Checked;
                    comboBox1.Enabled = checkBox1.Checked;
                    if (!checkBox1.Checked)
                    {
                        textBox.Text = string.Empty;
                        var pair = new KeyValuePair<ColumnInfo, SearchingTerm>(
                            (ColumnInfo) comboBox.SelectedItem,
                            new SearchingTerm(String.Empty, (SearchingMode) comboBox1.SelectedItem));
                        _observers.ForEach(en => en.OnNext(pair));
                    }
                }
                catch (Exception exception)
                {
                    _console?.AddException(exception);
                }
            };

            comboBox.TextChanged += (s, e) =>
            {
                try
                {
                    if (checkBox1.Checked && _priviousColumn != null)
                    {
                        var pair = new KeyValuePair<ColumnInfo, SearchingTerm>(
                            _priviousColumn, new SearchingTerm(String.Empty, (SearchingMode)comboBox1.SelectedItem));
                        _observers.ForEach(en => en.OnNext(pair));
                        textBox.Text = String.Empty;
                    }
                }
                catch (Exception exception)
                {
                    _console?.AddException(exception);
                }
            };

            Disposed += (s, e) =>
            {
                var pair = new KeyValuePair<ColumnInfo, SearchingTerm>(
                    (ColumnInfo) comboBox.SelectedItem,
                    new SearchingTerm(String.Empty, (SearchingMode) comboBox1.SelectedItem));
                _observers.ForEach(en => en.OnNext(pair));
            };
        }

        public void Initial(ICollection<ColumnInfo> columns, int chosing = -1)
        {
            try
            {
                comboBox1.DataSource = new BindingSource(SearchingMode.GetModes(), null);

                var source = columns
                    .Where(f => f.Visible)
                    .ToList();
                comboBox.DataSource = new BindingSource(source, null);

                var column = columns.SingleOrDefault(f => f.Num == chosing);
                if (column != null)
                {
                    comboBox.SelectedItem = column;
                }
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
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
        public IDisposable Subscribe(IObserver<KeyValuePair<ColumnInfo, SearchingTerm>> observer)
        {
            if (_observers == null)
                _observers = new List<IObserver<KeyValuePair<ColumnInfo, SearchingTerm>>>();
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return null;
        }
    }
}
