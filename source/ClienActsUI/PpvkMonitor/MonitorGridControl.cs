using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using OverWeightControl.Clients.ActsUI.Tools;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer;
using OverWeightControl.Core.Settings;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Clients.ActsUI.PpvkMonitor
{
    public partial class MonitorGridControl :
        UserControl,
        IEditable<ICollection<PpvkFileInfo>>,
        IEditable<ICollection<ColumnInfo>>,
        IObserver<IDictionary<ColumnInfo, SearchingTerm>>,
        IObserver<IList<DateFilter>>
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private IDictionary<ColumnInfo, SearchingTerm> _filters;
        private IList<DateFilter> _dateFilters;
        private ICollection<PpvkFileInfo> _data;
        private ICollection<ColumnInfo> _columns;
        private const int _pageSize = 50;
        private int _count;

        public MonitorGridControl()
        {
            //_fastAccess = new Dictionary<int, Guid>();
            InitializeComponent();
            InitialComponentsEvents();
            CreateFields<PpvkFileInfo>();
        }

        [InjectionConstructor]
        public MonitorGridControl(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;

            InitializeComponent();
            //_fastAccess = new Dictionary<int, Guid>();
            CreateFields<PpvkFileInfo>();
        }

        private void InitialComponentsEvents()
        {
            pageTextBox.KeyPress += (s, e) =>
            {
                var s2 = s;
                var e2 = e;
            };
            actGridView.ColumnHeaderMouseClick += (s, e) =>
            {
                try
                {
                    var column = ((DataGridView)s).Columns[e.ColumnIndex].Name;
                    if (column == null)
                        return;

                    _data = _data.ApplyOrder(column, "OrderBy").ToList();
                    LoadData(_data);
                }
                catch (Exception exception)
                {
                    _console.AddException(exception);
                }
            };
            firstButton.Click += (s, e) =>
            {
                try
                {
                    pageTextBox.Text = @"1";
                    LoadData(_data);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            };
            previousButton.Click += (s, e) =>
            {
                try
                {
                    if (int.TryParse(pageTextBox.Text, out int page)
                        && page > 1)
                    {
                        pageTextBox.Text = (page - 1).ToString();
                        LoadData(_data);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            };
            nextButton.Click += (s, e) =>
            {
                try
                {
                    if (int.TryParse(pageTextBox.Text, out int page)
                        && page * _pageSize < _count)
                    {
                        pageTextBox.Text = (page + 1).ToString();
                        LoadData(_data);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            };
            lastButton.Click += (s, e) =>
            {
                try
                {
                    pageTextBox.Text = (_count / _pageSize + 1).ToString();
                    LoadData(_data);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            };
        }

        public bool LoadData(ICollection<PpvkFileInfo> data)
        {
            if (_data == null)
                _data = data;
            if (actGridView.Rows.Count != data.Count)
                ToGrid(data);

            try
            {
                var outerList = _data.Select(m => m.Id).ToList();

                outerList = FindForDatesAtGrid(outerList);

                outerList = FindForFilterGrid<PpvkFileInfo>(outerList);

                ToGrid(data.Where(f => outerList.Contains(f.Id)).ToList());

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        /// <summary>
        /// Поиск фильтров
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="outerList"></param>
        /// <returns></returns>
        private List<Guid> FindForFilterGrid<T>(List<Guid> outerList)
        {
            try
            {
                if (_filters == null || !_filters.Any())
                    return outerList;

                foreach (var filter in _filters.Keys)
                {
                    var filterName = _columns.Single(s => s.Description == filter.Name).Name;
                    var t = typeof(T).GetProperty(filterName);
                    var innerFilterList = _data
                        .Where(f =>
                            // поиск по условию "Содержит"
                                _filters[filter].Mode.Mode == SearchingModeEnum.Contains
                                && t.GetValue(f).ToString().ToLower()
                                    .Contains(_filters[filter].SearchingData.ToLower())
                                // поиск по условию "Начинается с"
                                || _filters[filter].Mode.Mode == SearchingModeEnum.StartsWith
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
                    && f.FindAtPpvkTime.Date == _dateFilters.Single(a => a.Mode == DateSeachMode.OnDate).Date.Date
                    || _dateFilters.Any(a => a.Mode == DateSeachMode.FromDate)
                    && _dateFilters.Single(a => a.Mode == DateSeachMode.FromDate).Date.Date
                        .CompareTo(f.FindAtPpvkTime.Date) <= 0
                    && _dateFilters.Any(a => a.Mode == DateSeachMode.ToDate)
                    && _dateFilters.Single(a => a.Mode == DateSeachMode.ToDate).Date.Date
                        .CompareTo(f.FindAtPpvkTime.Date) >= 0)
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
        
        private void ToGrid(ICollection<PpvkFileInfo> data)
        {
            try
            {
                int page = int.TryParse(pageTextBox.Text, out int buf) ? buf : 1;
                if (String.IsNullOrEmpty(pageTextBox.Text))
                    pageTextBox.Text = page.ToString();
                var pageData = data.Skip(_pageSize * (page - 1)).Take(_pageSize).ToList();
                LoadToGrid(pageData, _columns, actGridView, _console);
                _count = data.Count;
                infoLabel.Text = _count != 0 
                    ? $"Загружено {_count} актов" 
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
                    .Select(propertyInfo => new ColumnInfo
                    {
                        Name = propertyInfo.Name,
                        Num = (int?)propertyInfo.CustomAttributes
                            .SingleOrDefault(f => f.AttributeType == typeof(JsonPropertyAttribute))
                            ?.NamedArguments[0].TypedValue.Value ?? -1,
                        Description = propertyInfo.CustomAttributes
                            .SingleOrDefault(f => f.AttributeType == typeof(DisplayNameAttribute))
                            ?.ConstructorArguments[0].Value.ToString() ?? String.Empty,
                        Visible = true
                    })
                    .OrderBy(o => o.Num)
                    .ToList();
                if (_columns.Min(m => m.Num) == 0)
                    _columns.ForEach(e => e.Num += 1);
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

        public bool UpdateData(ICollection<PpvkFileInfo> data)
        {
            try
            {
                if (data == null)
                    return false;

                data.Clear();
                var outerList = _data.Select(m => m.Id).ToList();

                outerList = FindForDatesAtGrid(outerList);

                outerList = FindForFilterGrid<PpvkFileInfo>(outerList);

                _data.Where(f => outerList.Contains(f.Id)).ForEach(data.Add);
                return data.Count > 0;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public bool LoadData(ICollection<ColumnInfo> data)
        {
            try
            {
                if (data == null)
                    data = new List<ColumnInfo>();
                data.Clear();

                for (int i = 0; i < actGridView.Columns.Count; i++)
                {
                    data.Add(new ColumnInfo
                    {
                        Num = i,
                        Description = actGridView.Columns[i].Name,
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

        public bool UpdateData(ICollection<ColumnInfo> data)
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
        public void OnNext(IDictionary<ColumnInfo, SearchingTerm> value)
        {
            try
            {
                _filters = value
                    .Where(f => !string.IsNullOrEmpty(f.Value.SearchingData))
                    .ToDictionary(k => k.Key, v => v.Value);
                pageTextBox.Text = @"1";
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

        internal static int LoadToGrid(
            List<PpvkFileInfo> data,
            ICollection<ColumnInfo> columns,
            DataGridView actGridView,
            IConsoleService console = null)
        {
            try
            {
                actGridView.Rows.Clear();
                foreach (var flatAct in data)
                {
                    var index = actGridView.Rows.Add();
                    foreach (var e in columns)
                    {
                        actGridView.Rows[index].Cells[e.Name].Value =
                            flatAct.GetType().GetProperty(e.Name)?.GetValue(flatAct, null);
                    }
                }

                return data.Count;
            }
            catch (Exception e)
            {
                console?.AddException(e);
                return 0;
            }
        }
    }
}
