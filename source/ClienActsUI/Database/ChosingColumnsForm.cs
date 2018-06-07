using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity.Attributes;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ChosingColumnsForm : Form, IEditable<ICollection<ColumnList>>
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

        public bool LoadData(ICollection<ColumnList> data)
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

        public bool UpdateData(ICollection<ColumnList> data)
        {
            throw new NotImplementedException();
            return false;
        }
    }
    
    public class ColumnList
    {
        public string Name { get; set; }
        public int Num { get; set; }
        public bool Visible { get; set; }
        public string Description { get; set; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => Name;
    }
}
