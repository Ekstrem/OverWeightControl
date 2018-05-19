using System.Collections.Generic;
using System.Windows.Forms;
using Unity.Attributes;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Clients;
using System;
using OverWeightControl.Core.Settings;

namespace OverWeightControl
{
    public partial class PackageAdmining : Form, IEditable<ICollection<NodeRole>>
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;

        public PackageAdmining()
        {
            InitializeComponent();

            FormClosing += (s, e) => Save();
        }

        [InjectionConstructor]
        public PackageAdmining(
            [OptionalDependency] IConsoleService console,
            [OptionalDependency] ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;

            InitializeComponent();
            LoadData(CompositionRoot.Instance.NodeRoles);

            FormClosing += (s, e) =>
            {
                if (((Form)s).DialogResult == DialogResult.OK)
                    Save();
            };

            tabPage1.Leave += (s, e) => UpdateData(CompositionRoot.Instance.NodeRoles);
            tabPage1.Leave += (s, e) =>
                dependencyListControl2.LoadData(CompositionRoot.Instance.WorkFlowDependencies);
            tabPage1.Leave += (s, e) =>
                dependencyListControl1.LoadData(CompositionRoot.Instance.InfrastructureDependencies);
        }

        #region IEditable<ICollection<NodeRole>> members

        public bool LoadData(ICollection<NodeRole> data)
        {
            try
            {
                checkBox1.Checked = data.Contains(NodeRole.PPVK);
                checkBox2.Checked = data.Contains(NodeRole.AFC);
                checkBox3.Checked = data.Contains(NodeRole.VerificationStation);
                checkBox4.Checked = data.Contains(NodeRole.ReportsStation);

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        public bool UpdateData(ICollection<NodeRole> data)
        {
            try
            {
                if (data == null)
                    data = new List<NodeRole>();
                data.Clear();
                if (checkBox1.Checked)
                    data.Add(NodeRole.PPVK);
                if (checkBox2.Checked)
                    data.Add(NodeRole.AFC);
                if (checkBox3.Checked)
                    data.Add(NodeRole.VerificationStation);
                if (checkBox4.Checked)
                    data.Add(NodeRole.ReportsStation);

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        #endregion
        
        private void Save()
        {
            dependencyListControl1.UpdateData(
                    CompositionRoot.Instance.InfrastructureDependencies);
            dependencyListControl2.UpdateData(
                CompositionRoot.Instance.WorkFlowDependencies);
            UpdateData(CompositionRoot.Instance.NodeRoles);

            CompositionRoot.Instance.SaveConfigToFile();
        }
    }
}
