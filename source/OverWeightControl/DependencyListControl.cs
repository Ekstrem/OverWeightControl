using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl
{
    public partial class DependencyListControl :
        UserControl,
        IEditable<ICollection<Dependency>>
    {
        private readonly IConsoleService _console;

        public DependencyListControl()
        {
            InitializeComponent();

            InitDataGrid();
        }

        [InjectionConstructor]
        public DependencyListControl(
            IConsoleService console)
        {
            _console = console;
        }

        private void InitDataGrid()
        {
            dataGrid.Columns[0].ValueType = typeof(int);
            dataGrid.Columns[1].ValueType = typeof(Type);
            dataGrid.Columns[2].ValueType = typeof(Type);
            dataGrid.Columns[3].ValueType = typeof(string);
            dataGrid.Columns[4].ValueType = typeof(bool);

            upButton.Click += (s, e) =>
            {
                int index = dataGrid?.CurrentRow?.Index ?? -1;
                if (index > 0)
                {
                    var data = new List<Dependency>();
                    UpdateData(data);
                    var result = data.ToArray();
                    var buf = result[index];
                    result[index] = result[index - 1];
                    result[index - 1] = buf;
                    LoadData(result.ToList());
                }
            };

            downButton.Click += (s, e) =>
            {
                int index = dataGrid?.CurrentRow?.Index ?? -1;
                if (index > -1 && index < dataGrid.Rows.Count)
                {
                    var data = new List<Dependency>();
                    UpdateData(data);
                    var result = data.ToArray();
                    var buf = result[index];
                    result[index] = result[index + 1];
                    result[index + 1] = buf;
                    LoadData(result.ToList());
                }
            };
        }

        public bool LoadData(ICollection<Dependency> data)
        {
            try
            {
                dataGrid.Rows.Clear();
                foreach (var dep in data)
                {
                    dep.Register = dep.AllowRoles
                        .Any(p => CompositionRoot.Instance.NodeRoles.Contains(p));

                    int rowNum = dataGrid.Rows.Add(
                        dep.Order,
                        dep.Abstractions.Name,
                        dep.Realization.Name,
                        dep.Name,
                        dep.Register);
                    dataGrid.Rows[rowNum].Tag = dep;
                }

                dataGrid.Update();

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        public bool UpdateData(ICollection<Dependency> data)
        {
            try
            {
                data.Clear();
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    var dep = (Dependency)dataGrid.Rows[i].Tag;
                    dep.Register = (bool) dataGrid.Rows[i].Cells[4].Value;
                    data.Add(dep);
                }

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }
    }
}
