using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
            if (actGridView.Rows.Count != data.Count)
                ToGrid(data);

            try
            {
                    var outerList = _data.Select(m => m.Id).ToList();
                    
                    outerList = FindForFilterAtGrid<FlatAct>(outerList);

                    outerList = FindForDatesAtGrid(outerList);
                    
                    ToGrid(data.Where(f => outerList.Contains(f.Id)).ToList());
                

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        private List<Guid> FindForFilterAtGrid<T>(List<Guid> outerList)
        {
            try
            {
                if (_filters == null || !_filters.Any())
                    return outerList;

                foreach (var filter in _filters.Keys)
                {
                    var filterName = _columns.Single(s => s.Description == filter.Name).Name;
                    var t = typeof(FlatAct).GetProperty(filterName);
                    var innerFilterList = _data
                        .Where(f =>
                            // поиск по условию "Содержит"
                                _filters[filter].Mode.Mode == SearchingModeEnum.Contains
                                && t.GetValue(f).ToString().ToLower()
                                    .Contains(_filters[filter].SearchingData.ToLower())
                                // поиск по условию "Начинается с"
                                || _filters[filter].Mode.Mode == SearchingModeEnum.StartWith
                                && t.GetValue(f).ToString().ToLower()
                                    .StartsWith(_filters[filter].SearchingData.ToLower()))
                        .Select(m => m.Id);

                    outerList = !outerList.Any()
                        ? innerFilterList.ToList()
                        : innerFilterList.Intersect(outerList).ToList();
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
            try { 
            if (_dateFilters == null || !_dateFilters.Any())
                return outerList;

            outerList = _data
                .Where(f =>
                    _dateFilters.Any(a => a.Mode == DateSeachMode.OnDate)
                    && f.ActDateTime.Date == _dateFilters.Single(a => a.Mode == DateSeachMode.OnDate).Date.Date
                    || _dateFilters.Any(a => a.Mode == DateSeachMode.FromDate)
                    && _dateFilters.Single(a => a.Mode == DateSeachMode.FromDate).Date.Date
                        .CompareTo(f.ActDateTime.Date) <= 0
                    && _dateFilters.Any(a => a.Mode == DateSeachMode.ToDate)
                    && _dateFilters.Single(a => a.Mode == DateSeachMode.ToDate).Date.Date
                        .CompareTo(f.ActDateTime.Date) >= 0)
                .Select(m => m.Id)
                .ToList();

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
                var count = FlatAct.LoadToGrid(data, _columns, actGridView, _console);
                infoLabel.Text = count != 0 
                    ? $"Загружено {count} актов" 
                    : String.Empty;
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
                        //TODO: Add Description
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
