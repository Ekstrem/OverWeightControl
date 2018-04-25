using System.Linq;
using System.Windows.Forms;

namespace OverWeightControl
{
    public partial class PackageAdmining : Form
    {
        public PackageAdmining()
        {
            InitializeComponent();
        }

        public static void ShowModal()
        {
            var form = new PackageAdmining();
            form.dependencyListControl1.LoadData(
                CompositionRoot.Instance.InfrastructureDependencies);
            form.dependencyListControl2.LoadData(
                CompositionRoot.Instance.WorkFlowDependencies);
            form.checkBox1.Checked = CompositionRoot.Instance.NodeRoles.Contains(NodeRole.PPVK);
            form.checkBox2.Checked = CompositionRoot.Instance.NodeRoles.Contains(NodeRole.AFC);
            form.checkBox3.Checked = CompositionRoot.Instance.NodeRoles.Contains(NodeRole.VerificationStation);
            form.checkBox4.Checked = CompositionRoot.Instance.NodeRoles.Contains(NodeRole.ReportsStation);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.dependencyListControl1.UpdateData(
                    CompositionRoot.Instance.InfrastructureDependencies);
                form.dependencyListControl2.UpdateData(
                    CompositionRoot.Instance.WorkFlowDependencies);

                CompositionRoot.Instance.NodeRoles.Clear();
                if (form.checkBox1.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.PPVK);
                if (form.checkBox2.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.AFC);
                if (form.checkBox3.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.VerificationStation);
                if (form.checkBox4.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.ReportsStation);

                CompositionRoot.Instance.SaveConfigToFile();
            }
        }
    }
}
