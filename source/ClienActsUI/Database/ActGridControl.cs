using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ActGridControl :
        UserControl,
        IEditable<ICollection<FlatAct>>,
        IEditable<ICollection<ColumnList>>,
        IObserver<IDictionary<ColumnList, SearchingTerm>>,
        IObserver<IList<DateFilter>>
    {
        private readonly IDictionary<int, Guid> _fastAccess;
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private IDictionary<ColumnList, SearchingTerm> _filters;
        private IList<DateFilter> _dateFilters;
        private ICollection<FlatAct> _data;
        private ICollection<ColumnList> _columns;

        public ActGridControl()
        {
            _fastAccess = new Dictionary<int, Guid>();
            InitializeComponent();
            CreateFields<FlatAct>();
        }

        [InjectionConstructor]
        public ActGridControl(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;

            InitializeComponent();
            _fastAccess = new Dictionary<int, Guid>();
        }

        public bool LoadData(ICollection<FlatAct> data)
        {
            if (_data == null)
                _data = data;
            ToGrid(data);

            try
            {
                if (_filters != null && _filters.Any()
                    || _dateFilters != null && _dateFilters.Any())
                {
                    var outerList = _data.Select(m => m.Id).ToList();
                    
                    outerList = FindForFilterAtGrid(outerList);

                    outerList = FindForDatesAtGrid(outerList);

                    ToGrid(data.Where(f => outerList.Contains(f.Id)).ToList());
                }

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        private List<Guid> FindForFilterAtGrid(List<Guid> outerList)
        {
            try
            {
                if (_filters == null)
                    return outerList;
                
                foreach (var filter in _filters?.Keys)
                {
                    var innerFilterList = new List<Guid>();
                    var columnName = filter != null ? actGridView.Columns[filter.Num].Name : null;
                    for (int i = 0; i < actGridView.Rows.Count; i++)
                    {
                        var value = actGridView.Rows[i].Cells[columnName]?.Value?.ToString();
                        if (value != null
                            && !string.IsNullOrEmpty(filter.Name)
                            && _filters != null
                            && _filters.ContainsKey(filter)
                            // поиск по условию "Содержит"
                            && (_filters[filter].Mode.Mode == SearchingModeEnum.Contains
                                && value.ToLower().Contains(_filters[filter].SearchingData.ToLower())
                                // поиск по условию "Начинается с"
                                || _filters[filter].Mode.Mode == SearchingModeEnum.StartWith
                                && value.ToLower().StartsWith(_filters[filter].SearchingData.ToLower())))
                        {
                            var buf = actGridView.Rows[i].Cells["Id"].Value.ToString();
                            Guid.TryParse(buf, out Guid id);
                            innerFilterList.Add(id);
                        }
                    }

                    outerList = !outerList.Any()
                        ? innerFilterList.ToList()
                        : innerFilterList.Intersect(outerList).ToList();
                    innerFilterList.Clear();
                }

                return outerList;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return outerList;
            }
        }

        private List<Guid> FindForDatesAtGrid(List<Guid> outerList)
        {
            try
            {
                var innerDatesList = new List<Guid>();
                for (int i = 0; i < actGridView.Rows.Count; i++)
                {
                    var buf = actGridView.Rows[i].Cells["ActDateTime"].Value?.ToString().Trim();
                    DateTime.TryParse(buf, out var date);
                    if (_dateFilters != null && date != null &&
                        (_dateFilters.Any(f => f.Mode == DateSeachMode.OnDate)
                         && date.Date == _dateFilters.Single(f => f.Mode == DateSeachMode.OnDate).Date.Date
                         || _dateFilters.Any(f => f.Mode == DateSeachMode.FromDate)
                         && _dateFilters.Single(f => f.Mode == DateSeachMode.FromDate).Date.Date.CompareTo(date.Date) <=
                         0
                         && _dateFilters.Any(f => f.Mode == DateSeachMode.ToDate)
                         && _dateFilters.Single(f => f.Mode == DateSeachMode.ToDate).Date.Date.CompareTo(date.Date) >=
                         0))
                    {
                        var res = actGridView.Rows[i].Cells["Id"].Value.ToString();
                        Guid.TryParse(res, out Guid id);
                        innerDatesList.Add(id);
                    }
                }
                
                outerList = !outerList.Any()
                    ? innerDatesList.ToList()
                    : innerDatesList.Intersect(outerList).ToList();
                innerDatesList.Clear();

                return outerList;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return new List<Guid>();
            }
        }
        
        private void ToGrid(ICollection<FlatAct> data)
        {
            try
            {
                actGridView.Rows.Clear();
                foreach (var flatAct in data)
                {
                    var index = actGridView.Rows.Add();
                    foreach (var e in _columns)
                    {
                        actGridView.Rows[index].Cells[e.Name].Value =
                            flatAct.GetType().GetProperty(e.Name).GetValue(flatAct, null);
                    }
                }

                infoLabel.Text = data.Any() ? $"Загружено {data.Count} актов" : String.Empty;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
        }

        private void CreateFields<T>()
        {
            try
            {
                _columns = typeof(T)
                    .GetProperties()
                    .Select(propertyInfo => new ColumnList
                    {
                        Name = propertyInfo.Name,
                        Num = (int)propertyInfo.CustomAttributes
                            .Single(f => f.AttributeType == typeof(JsonPropertyAttribute))
                            .NamedArguments[0].TypedValue.Value,
                        Description = propertyInfo.CustomAttributes
                            .Single(f => f.AttributeType == typeof(DisplayNameAttribute))
                            .ConstructorArguments[0].Value.ToString(),
                        Visible = true
                    })
                    .OrderBy(o => o.Num)
                    .ToList();
                _columns.ForEach(e => actGridView.Columns.Add(e.Name, e.Description));
            }
            catch (Exception e)
            {
                _console?.AddException(e);
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
        public void OnNext(IDictionary<ColumnList, SearchingTerm> value)
        {
            try
            {
                _filters = value
                    .Where(f => !string.IsNullOrEmpty(f.Value.SearchingData))
                    .ToDictionary(k => k.Key, v => v.Value);
                LoadData(_data);
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
        }

        /// <summary>Предоставляет наблюдателю новые данные.</summary>
        /// <param name="value">Текущие сведения об уведомлениях.</param>
        public void OnNext(IList<DateFilter> value)
        {
            try
            {
                _dateFilters = value;
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
