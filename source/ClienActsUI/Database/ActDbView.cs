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

            this.button1.Click += (s, e) =>
            {
                Guid index = actGridControl1.GetMarked();
                var act = _context.Acts
                    .FirstOrDefault(f => f.Id == index);
                act.Cargo = _context.Cargos
                    .FirstOrDefault(f => f.Id == index);
                act.Driver = _context.Drivers
                    .FirstOrDefault(f => f.Id == index);
                act.Weighter = _context.Weighters
                    .FirstOrDefault(f => f.Id == index);
                act.Vehicle = _context.Vehicles
                    .FirstOrDefault(f => f.Id == index);

                ActEditForm.ShowModal(container, act);
            };
        }

        private void LoadData()
        {
            try
            {
                var acts = _context.Acts.Select(m => m).ToList();
                actGridControl1.LoadData(acts);
            }
            catch (Exception e)
            {
                _console.AddException(e);
                this.Close();
            }
        }
    }
}
