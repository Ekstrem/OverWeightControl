using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OverWeightControl.Core.Clients;

namespace OverWeightControl
{
    public partial class DependencyListControl :
        UserControl,
        IEditable<ICollection<Dependency>>
    {
        public DependencyListControl()
        {
            InitializeComponent();

            dataGrid.Columns[0].ValueType = typeof(int);
            dataGrid.Columns[1].ValueType = typeof(Type);
            dataGrid.Columns[2].ValueType = typeof(Type);
            dataGrid.Columns[3].ValueType = typeof(string);
            dataGrid.Columns[4].ValueType = typeof(bool);

        }

        public bool LoadData(ICollection<Dependency> data)
        {
            foreach (var dep in data)
            {
                int rowNum = dataGrid.Rows.Add(
                    dep.Order,
                    dep.Abstractions.Name,
                    dep.Realization.Name,
                    dep.Name,
                    dep.Register);
                dataGrid.Rows[rowNum].Tag = dep;
            }

            return false;
        }

        public bool UpdateData(ICollection<Dependency> data)
        {
            throw new NotImplementedException();
        }
    }
}
