using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Newtonsoft.Json;
using Unity;
using Unity.Attributes;

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
            _context = (ModelContext)context;

            InitializeComponent();

            InitialComponentsEvents();

            Task.Factory.StartNew(() => this.Invoke((Action)LoadData));
        }

        private void InitialComponentsEvents()
        {
            editActButton.Click += (s, e) =>
              {
                  Guid index = actGridControl1.GetMarked();
                  var act = _acts.FirstOrDefault(f => f.Id == index);
                  ActEditForm.ShowModal(_container, act);
                  int changed = _context.SaveChanges();
                  if (changed != 0)
                      LoadData();
              };
            columnsListEditButton.Click += (s, e) =>
            {
                try
                {
                    var columns = new List<ColumnList>();
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
        }

        private void LoadData()
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
                actGridControl1.LoadData(_acts.Select(FlatAct.Expand).ToList());

                if (File.Exists(_fileName))
                {
                    var json = File.ReadAllText(_fileName);
                    var columns = JsonConvert.DeserializeObject<List<ColumnList>>(json);
                    actGridControl1.UpdateData(columns);
                }
            }
            catch (Exception e)
            {
                _console.AddException(e);
                this.Close();
            }
        }
    }
}
