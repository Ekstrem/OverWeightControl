using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class MainForm : Form
    {
        private readonly IUnityContainer _container;

        [InjectionConstructor]
        public MainForm(IUnityContainer container)
        {
            _container = container;
            InitializeComponent();

            // Станция верфикации
            actListVerificationToolStripMenuItem.Click += (s, e) => StartForm("ActEditForm");
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
            adminingToolStripMenuItem.Visible = adminMode;

            if (roles == null)
                return;

            foreach (var role in roles)
            {
                switch(role)
                {
                    case NodeRole.PPVK:
                        syncToolStripMenuItem.Visible = true;
                        break;
                    case NodeRole.AFC:
                        storageCommitmentToolStripMenuItem.Visible = true;
                        break;
                    case NodeRole.VerificationStation:
                        verificationStationToolStripMenuItem.Visible = true;
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
