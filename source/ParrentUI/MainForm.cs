using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class MainForm : Form
    {
        public MainForm(IUnityContainer container)
        {
            InitializeComponent();

            actListVerificationToolStripMenuItem.Click += (s, e) =>
                container.Resolve<Form>("ActEditForm");
            // actVerificationWizardToolStripMenuItem.Click += (s, e) =>
            adminingToolStripMenuItem.Click += (s, e) =>
                container.Resolve<Form>("PackageAdmining");
            
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
    }
}
