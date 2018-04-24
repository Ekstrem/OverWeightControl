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
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.dependencyListControl1.UpdateData(
                    CompositionRoot.Instance.InfrastructureDependencies);
                form.dependencyListControl2.UpdateData(
                    CompositionRoot.Instance.WorkFlowDependencies);
            }
        }
    }
}
