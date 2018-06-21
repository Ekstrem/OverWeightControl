using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OverWeightControl.Clients.ActsUI.Tools;
using Unity.Attributes;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ChosingColumnsForm : Form, IEditable<ICollection<ColumnInfo>>
    {
        private readonly IConsoleService _console;
        public ChosingColumnsForm()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public ChosingColumnsForm(
            IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        public bool LoadData(ICollection<ColumnInfo> data)
        {
            try
            {
                dataGridView1.DataSource = new BindingSource(data, null);
                return true;
            }
            catch (Exception ex)
            {
                _console?.AddException(ex);
                return false;
            }
        }

        public bool UpdateData(ICollection<ColumnInfo> data)
        {
            return false;
        }
    }
}
