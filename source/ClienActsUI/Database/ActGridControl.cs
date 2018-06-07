using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ActGridControl :
        UserControl,
        IEditable<ICollection<FlatAct>>,
        IEditable<ICollection<ColumnList>>,
        IObserver<IDictionary<ColumnList, string>>
    {
        private readonly IDictionary<int, Guid> _fastAccess;
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private IDictionary<ColumnList, string> _filters;
        private ICollection<FlatAct> _data;

        public ActGridControl()
        {
            _fastAccess = new Dictionary<int, Guid>();
            InitializeComponent();
        }

        [InjectionConstructor]
        public ActGridControl(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;

            InitializeComponent();
            // idColum.Visible = bool.TryParse(_settings[ArgsKeyList.IsDebugMode], out bool result) && result;
            _fastAccess = new Dictionary<int, Guid>();
        }

        public bool LoadData(ICollection<FlatAct> data)
        {
            _data = data;

            try
            {
                // actGridView.Columns.Clear();
                var list = new List<string>();

                if (_filters != null && _filters.Count != 0 && actGridView.Columns.Count > 0)
                {
                    foreach (var filter in _filters.Keys)
                    {
                        var columnName = actGridView.Columns[filter.Num].Name;
                        //bs.Filter = $"[{columnName}] LIKE '{_filters[filter]}%'";
                        for (int i = 0; i < actGridView.Rows.Count; i++)
                        {
                            var value = actGridView.Rows[i].Cells[columnName]?.Value?.ToString();
                            if (value!= null && value.StartsWith(_filters[filter]))
                                list.Add(actGridView.Rows[i].Cells["Id"].Value.ToString());
                        }
                    }
                    actGridView.DataSource =
                        new BindingSource(data.Where(f => list.Contains(f.Id.ToString())).ToList(), null);
                }
                else
                actGridView.DataSource = new BindingSource(data, null);


                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public Guid GetMarked()
        {
            return (Guid?)actGridView?.CurrentRow?.Cells["Id"]?.Value ?? Guid.Empty;
        }

        public bool UpdateData(ICollection<FlatAct> data)
        {
            return false;
        }

        public bool LoadData(ICollection<ColumnList> data)
        {
            try
            {
                if (data == null)
                    data = new List<ColumnList>();
                data.Clear();

                for (int i = 0; i < actGridView.Columns.Count; i++)
                {
                    data.Add(new ColumnList
                    {
                        Num = i,
                        Name = actGridView.Columns[i].HeaderText,
                        Visible = actGridView.Columns[i].Visible
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                _console?.AddException(ex);
                return false;
            }
        }

        public bool UpdateData(ICollection<ColumnList> data)
        {
            try
            {
                if (data == null)
                    return false;

                for (int i = 0; i < actGridView.Columns.Count; i++)
                {
                    actGridView.Columns[i].Visible = data.Single(f => f.Num == i).Visible;
                }
                return true;
            }
            catch (Exception ex)
            {
                _console?.AddException(ex);
                return false;
            }
        }

        /// <summary>Предоставляет наблюдателю новые данные.</summary>
        /// <param name="value">Текущие сведения об уведомлениях.</param>
        public void OnNext(IDictionary<ColumnList, string> value)
        {
            try
            {
                _filters = value
                    .Where(f => !string.IsNullOrEmpty(f.Value))
                    .ToDictionary(k => k.Key, v => v.Value);
                LoadData(_data);
            }
            catch (Exception e)
            {
                _console?.AddException(e);
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

        internal void CopyAlltoClipboard()
        {
            actGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            actGridView.MultiSelect = true;
            actGridView.SelectAll();
            DataObject dataObj = actGridView.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            actGridView.MultiSelect = false;
        }
    }
}
