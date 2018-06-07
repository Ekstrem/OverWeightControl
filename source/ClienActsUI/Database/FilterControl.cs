using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using Unity.Attributes;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class FilterControl : 
        UserControl,
        IObservable<KeyValuePair<ColumnList, string>>
    {
        private readonly IConsoleService _console;
        private List<IObserver<KeyValuePair<ColumnList, string>>> _observers;
        private ColumnList _priviousColumn;

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

                    _priviousColumn = (ColumnList) comboBox.SelectedItem;
                    var pair = new KeyValuePair<ColumnList, string>(
                        (ColumnList)comboBox.SelectedItem,
                        ((TextBox)s).Text);
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
                    if (!checkBox1.Checked)
                    {
                        textBox.Text = string.Empty;
                        var pair = new KeyValuePair<ColumnList, string>(
                            (ColumnList)comboBox.SelectedItem,
                            String.Empty);
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
                        var pair = new KeyValuePair<ColumnList, string>(
                            _priviousColumn, String.Empty);
                        _observers.ForEach(en => en.OnNext(pair));
                        textBox.Text = String.Empty;
                    }
                }
                catch (Exception exception)
                {
                    _console?.AddException(exception);
                }
            };
        }

        public void Initial(ICollection<ColumnList> columns, int chosing = -1)
        {
            try
            {
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
        public IDisposable Subscribe(IObserver<KeyValuePair<ColumnList, string>> observer)
        {
            if (_observers == null)
                _observers = new List<IObserver<KeyValuePair<ColumnList, string>>>();
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return null;
        }
    }
}
