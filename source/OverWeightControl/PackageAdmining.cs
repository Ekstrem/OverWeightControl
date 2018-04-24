using System.Windows.Forms;

namespace OverWeightControl
{
    public partial class PackageAdmining : Form
    {
        public PackageAdmining()
        {
            InitializeComponent();
        }

        public bool LoadInfrasructureData(CompositionRoot cr)
        {
            return dependencyListControl1
                .LoadData(cr.InfrastructureDependencies);
        }
    }
}
