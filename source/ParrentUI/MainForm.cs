using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class MainForm : Form
    {
        private readonly IUnityContainer _container;
        private readonly ISettingsStorage _settings;
        private bool _adminMode;

        [InjectionConstructor]
        public MainForm(
            IUnityContainer container,
            ISettingsStorage settings)
        {
            _container = container;
            _settings = settings;
            InitializeComponent();
            TopLevel = true;

            // Станция верфикации
            actListVerificationToolStripMenuItem.Click += (s, e) => StartForm("ValidationForm");
            // actVerificationWizardToolStripMenuItem.Click += (s, e) =>

            // Администрирование
            settingsToolStripMenuItem.Click += (s, e) => StartForm("EditorSettingsStorage");
            nodeRolesToolStripMenuItem.Click += (s, e) => StartForm("PackageAdmining");
        }

        public void Initial(ICollection<NodeRole> roles, bool adminMode = false)
        {
            syncToolStripMenuItem.Visible = false;
            storageCommitmentToolStripMenuItem.Visible = false;
            verificationStationToolStripMenuItem.Visible = false;
            reportsStationToolStripMenuItem.Visible = false;
            label1.Visible = false;
            progressListControl1.Visible = false;
            adminingToolStripMenuItem.Visible = adminMode;

            bool debug = Boolean.TryParse(_settings.Key(ArgsKeyList.IsDebugMode), out debug) && debug;
            if (roles == null || (adminMode && !debug))
                return;

            foreach (var role in roles)
            {
                switch(role)
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

        private void StartForm(string dependencyName)
        {
            var form = _container.Resolve<Form>(dependencyName);
            // TODO: set parent conrol.
            // form.TopLevel = false;
            // form.Parent = this;
            form.ShowDialog();
        }
    }
}
