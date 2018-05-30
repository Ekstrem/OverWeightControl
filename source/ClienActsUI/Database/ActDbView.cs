using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ActDbView : Form
    {
        private readonly ISettingsStorage _settings;
        private readonly IConsoleService _console;
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
            _context = (ModelContext)context;

            InitializeComponent();

            LoadData();

            this.editActButton.Click += (s, e) =>
            {
                Guid index = actGridControl1.GetMarked();
                var act = _acts.FirstOrDefault(f => f.Id == index);
                ActEditForm.ShowModal(container, act);
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
            }
            catch (Exception e)
            {
                _console.AddException(e);
                this.Close();
            }
        }
    }
}
