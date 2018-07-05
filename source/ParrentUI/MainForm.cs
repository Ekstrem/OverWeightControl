using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using OverWeightControl.Core.Upgrade;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class MainForm : Form
    {
        private readonly IUnityContainer _container;
        private readonly ISettingsStorage _settings;
        private readonly IConsoleService _console;
        private readonly UpdateClient _updateClient;
        private Form _actDbView;

        [InjectionConstructor]
        public MainForm(
            IUnityContainer container,
            ISettingsStorage settings,
            IConsoleService console)
        {
            _container = container;
            _settings = settings;
            _console = console;
            if (container.Registrations.Any(a => a.RegisteredType == typeof(UpdateClient)))
                _updateClient = container.Resolve<UpdateClient>();
            InitializeComponent();
            TopLevel = true;

            IntitForms();

            // Администрирование
            settingsToolStripMenuItem.Click += (s, e) => StartForm("EditorSettingsStorage");
            nodeRolesToolStripMenuItem.Click += (s, e) => StartForm("PackageAdmining");
        }

        private void IntitForms()
        {
            // Станция верфикации
            actListVerificationToolStripMenuItem.Text = @"Просмотр актов";
            actListVerificationToolStripMenuItem.Click += (s, e) => _actDbView?.ShowDialog(); //StartForm("ActDbView");
            actVerificationWizardToolStripMenuItem.Text = @"Монитор Актов"; //TODO: это должно быть на другом пунте меню.
            actVerificationWizardToolStripMenuItem.Click += (s, e) => StartForm("MonitorDbView");
        }

        public async void Initial(ICollection<NodeRole> roles, bool adminMode = false)
        {
            try
            {
                syncToolStripMenuItem.Visible = false;
                storageCommitmentToolStripMenuItem.Visible = false;
                verificationStationToolStripMenuItem.Visible = false;
                reportsStationToolStripMenuItem.Visible = false;
                label1.Visible = false;
                progressListControl1.Visible = false;
                adminingToolStripMenuItem.Visible = adminMode;

                bool debug = Boolean.TryParse(_settings[ArgsKeyList.IsDebugMode], out debug) && debug;
                if (roles == null || (adminMode && !debug))
                    return;

                foreach (var role in roles)
                {
                    switch (role)
                    {
                        case NodeRole.PPVK:
                            syncToolStripMenuItem.Visible = true;
                            label1.Visible = true;
                            progressListControl1.Visible = true;
                            break;
                        case NodeRole.AFC:
                            storageCommitmentToolStripMenuItem.Visible = true;
                            label1.Visible = true;
                            progressListControl1.Visible = true;
                            break;
                        case NodeRole.VerificationStation:
                            verificationStationToolStripMenuItem.Visible = true;
                            label1.Visible = true;
                            progressListControl1.Visible = true;
                            await ActViewFunc();
                            break;
                        case NodeRole.ReportsStation:
                            reportsStationToolStripMenuItem.Visible = true;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }

        private void StartForm(string dependencyName)
        {
            try
            {
                var form = _container.Resolve<Form>(dependencyName);
                // TODO: set parent conrol.
                // form.TopLevel = false;
                // form.Parent = this;
                form.ShowDialog();
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }

        private async Task ActViewFunc()
        {
            try
            {
                const string methodName = @"LoadDataFromDataBaseAsync";
                _actDbView = _container.Resolve<Form>("ActDbView");
                MethodInfo m = _actDbView.GetType().GetMethod(methodName);
                await Task.Factory.StartNew(() => m.Invoke(_actDbView, null));
            }
            catch (Exception e)
            {
                _console.AddException(e);
            }
        }
    }
}
