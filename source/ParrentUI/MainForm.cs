using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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

            // Станция верфикации
            actListVerificationToolStripMenuItem.Click += (s, e) => StartForm("ActDbView");
            actVerificationWizardToolStripMenuItem.Click += (s, e) => StartForm("MonitorDbView");

            // Администрирование
            settingsToolStripMenuItem.Click += (s, e) => StartForm("EditorSettingsStorage");
            nodeRolesToolStripMenuItem.Click += (s, e) => StartForm("PackageAdmining");
            
            openHelpToolStripMenuItem.Click += (s, e) =>
            {
                try
                {
                    var fileName = $"..\\docs\\help.pdf";
                    if (!File.Exists(fileName))
                        throw new FileNotFoundException("Help.pdf not found");
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    _console.AddException(ex);
                }
            };
        }

        public void Initial(ICollection<NodeRole> roles, bool adminMode = false)
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
    }
}
