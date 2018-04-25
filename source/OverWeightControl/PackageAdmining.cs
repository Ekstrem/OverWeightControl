using System.Collections.Generic;
using System.Windows.Forms;
using Unity.Attributes;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Clients;
using System;

namespace OverWeightControl
{
    public partial class PackageAdmining : Form, IEditable<ICollection<NodeRole>>
    {
        private readonly IConsoleService _console;

        public PackageAdmining()
        {
            InitializeComponent();
            Init();

            FormClosing += (s, e) => Save();
        }

        [InjectionConstructor]
        public PackageAdmining(
            [OptionalDependency] IConsoleService console)
        {
            _console = console;

            InitializeComponent();
            Init();

            FormClosing += (s, e) =>
            {
                if (((Form)s).DialogResult == DialogResult.OK)
                    Save();
            };
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
                CompositionRoot.Instance.NodeRoles.Clear();
                if (checkBox1.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.PPVK);
                if (checkBox2.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.AFC);
                if (checkBox3.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.VerificationStation);
                if (checkBox4.Checked)
                    CompositionRoot.Instance.NodeRoles.Add(NodeRole.ReportsStation);

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        #endregion

        private void Init()
        {
            dependencyListControl1.LoadData(
                CompositionRoot.Instance.InfrastructureDependencies);
            dependencyListControl2.LoadData(
                CompositionRoot.Instance.WorkFlowDependencies);
            LoadData(CompositionRoot.Instance.NodeRoles);            
        }

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
