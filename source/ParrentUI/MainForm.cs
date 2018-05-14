using System.Collections.Generic;
using System.Windows.Forms;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using Unity;
using Unity.Attributes;
using Unity.Injection;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class MainForm : Form
    {
        private readonly IUnityContainer _container;
        private Timer _timer = new Timer {Interval = 60000};

        [InjectionConstructor]
        public MainForm(IUnityContainer container)
        {
            _container = container;
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

            if (roles == null)
                return;

            foreach (var role in roles)
            {
                switch(role)
                {
                    case NodeRole.PPVK:
                        syncToolStripMenuItem.Visible = true;
                        label1.Visible = true;
                        progressListControl1.Visible = true;
                        _timer.Tick += (s, e) =>
                            progressListControl1.LoadData(
                                _container.Resolve<IWorkFlowProducerConsumer>()
                                    .GetStatistic());
                        _timer.Start();
                        break;
                    case NodeRole.AFC:
                        storageCommitmentToolStripMenuItem.Visible = true;
                        label1.Visible = true;
                        progressListControl1.Visible = true;
                        _timer.Tick += (s, e) =>
                            progressListControl1.LoadData(
                                _container.Resolve<IWorkFlowProducerConsumer>()
                                    .GetStatistic());
                        _timer.Start();
                        break;
                    case NodeRole.VerificationStation:
                        verificationStationToolStripMenuItem.Visible = true;
                        label1.Visible = true;
                        progressListControl1.Visible = true;
                        _timer.Tick += (s, e) =>
                            progressListControl1.LoadData(
                                _container.Resolve<IWorkFlowProducerConsumer>()
                                    .GetStatistic());
                        _timer.Start();
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
