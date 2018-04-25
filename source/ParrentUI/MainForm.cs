using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
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
