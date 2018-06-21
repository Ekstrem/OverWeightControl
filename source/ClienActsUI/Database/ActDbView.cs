using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Newtonsoft.Json;
using Unity;
using Unity.Attributes;

using Excel = Microsoft.Office.Interop.Excel;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ActDbView : Form
    {
        private const string _fileName = "columns.cfg";
        private readonly ISettingsStorage _settings;
        private readonly IConsoleService _console;
        private readonly IUnityContainer _container;
        private readonly ModelContext _context;
        private List<Act> _acts;

        public ActDbView()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public ActDbView(
            ISettingsStorage settings,
            IConsoleService console,
            IUnityContainer container,
            DbContext context)
        {
            _settings = settings;
            _console = console;
            _container = container;
            _context = (ModelContext) context;

            InitializeComponent();

            InitialComponentsEvents();

            ((IObservable<IDictionary<ColumnInfo, SearchingTerm>>)this.filtersDockControl1).Subscribe(this.actGridControl1);
            ((IObservable<IList<DateFilter>>) this.filtersDockControl1).Subscribe(this.actGridControl1);

            _console?.AddEvent($"{nameof(ActDbView)} form created.");
        }

        private void InitialComponentsEvents()
        {
            editActButton.Click += (s, e) =>
              {
                  Guid index = actGridControl1.GetMarked();
                  var act = _acts.FirstOrDefault(f => f.Id == index);
                  ActEditForm.ShowModal(_container, act);
                  int changed = _context.SaveChanges();
                  _console.AddEvent($"Внесено {changed} изменений");
                  if (changed != 0)
                      LoadDataToGrid();
              };
            columnsListEditButton.Click += (s, e) =>
            {
                try
                {
                    var columns = new List<ColumnInfo>();
                    actGridControl1.LoadData(columns);
                    using (var form = new ChosingColumnsForm(_console))
                    {
                        if (form.LoadData(columns)
                            && form.ShowDialog() == DialogResult.OK
                            && actGridControl1.UpdateData(columns)) { }
                    }

                    var json = JsonConvert.SerializeObject(columns, Formatting.Indented);
                    File.WriteAllText(_fileName, json);
                }
                catch (Exception ex)
                {
                    _console?.AddException(ex);
                }
            };
            openOriginalFileButton.Click += (s, e) =>
            {
                try
                {
                    Guid index = actGridControl1.GetMarked();
                    var act = _acts.FirstOrDefault(f => f.Id == index);
                    string directory = _settings[ArgsKeyList.BackUpPath];
                    var fileName = Directory.GetFiles(
                        _settings[ArgsKeyList.BackUpPath]
                        , $"{act.Id}.*")
                        .FirstOrDefault(f => !f.Contains(".json"));
                    if (fileName == null)
                        return;
                    BroserForm.ShowModal(_console, fileName, act.ActNumber.ToString());
                }
                catch (Exception ex)
                {
                    _console?.AddException(ex);
                }
            };
            updateDataButton.Click += (s, e) => Task.Factory.StartNew(
                () => Invoke((Action)LoadDataToGrid));
            excelExportButton.Click += (s, e) => ExportToExcel();
            Load += (s, e) => Task.Factory.StartNew(
                () => Invoke((Action)LoadDataToGrid));
        }

        private void LoadDataToGrid()
        {
            try
            {
                if (_acts == null || !_acts.Any())
                {
                    LoadDataFromDataBase();
                }

                actGridControl1.LoadData(_acts.Select(FlatAct.Expand).ToList());

                // загрузка отображаемых колонок
                if (File.Exists(_fileName))
                {
                    var json = File.ReadAllText(_fileName);
                    var columns = JsonConvert.DeserializeObject<List<ColumnInfo>>(json);
                    actGridControl1.UpdateData(columns);
                    filtersDockControl1.InitColumns(columns);
                }

                _console?.AddEvent($"Loaded acts from DB. Count: {_acts.Count}");
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                this.Close();
            }
        }

        private void LoadDataFromDataBase()
        {
            try
            {
                _acts = _context
                    .Set<Act>()
                    .Include(d => d.Driver)
                    .Include(c => c.Cargo)
                    .Include(w => w.Weighter)
                    .Include(v => v.Vehicle)
                    .ToList();
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
        }

        private void ExportToExcel()
        {
            try
            {
                ICollection<FlatAct> rowsList = new List<FlatAct>();
                actGridControl1.UpdateData(rowsList);
                var rows = rowsList.ToArray();
                ICollection<ColumnInfo> columnsList = new List<ColumnInfo>();
                actGridControl1.LoadData(columnsList);
                var columns = columnsList.ToArray();

                Excel.Application xlexcel;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = Missing.Value;
                xlexcel = new Excel.Application();
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);

                for (int i = 0; i < columns.Length; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = columns[i].Name;
                }
                
                for (int i = 0; i < rows.Length; i++)
                {
                    for (int j = 0; j < columns.Length; j++)
                    {
                        try
                        {
                            var column = columns[j].Description;
                            var props = rows[i].GetType().GetProperty(column);
                            var buf = props?.GetValue(rows[i], null);
                            xlWorkSheet.Cells[i + 2, j + 1] = buf;
                        }
                        catch (Exception e)
                        {
                            _console?.AddException(e);
                        }
                    }
                }

                Excel.Range rng = (Excel.Range)xlWorkSheet.Rows[1];
                rng.Font.Bold = true;
                
                xlWorkSheet.Columns.AutoFit();

                xlexcel.Visible = true;
                xlexcel.UserControl = true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
            }
        }
    }
}
