using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class ActGridControl : UserControl, IEditable<ICollection<Act>>
    {
        private readonly IDictionary<int, Guid> _fastAccess;
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;

        public ActGridControl()
        {
            _fastAccess = new Dictionary<int, Guid>();
            InitializeComponent();
        }

        [InjectionConstructor]
        public ActGridControl(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;

            InitializeComponent();
            idColum.Visible = bool
                .TryParse(_settings[ArgsKeyList.IsDebugMode], out bool result) && result;
            _fastAccess = new Dictionary<int, Guid>();
        }

        public bool LoadData(ICollection<Act> data)
        {
            try
            {
                _fastAccess.Clear();
                actGridView.Rows.Clear();
                foreach (var act in data)
                {
                    int index = actGridView.Rows.Add();
                    actGridView.Rows[index].Cells[nameof(idColum)].Value = act.Id;
                    actGridView.Rows[index].Cells[nameof(actNumber)].Value = act.ActNumber;
                    actGridView.Rows[index].Cells[nameof(DateTimeColumn)].ValueType = typeof(string);
                    actGridView.Rows[index].Cells[nameof(DateTimeColumn)].Value = act.ActDateTime;
                    actGridView.Rows[index].Cells[nameof(ppvkNumColumn)].Value = act.PpvkNumber;
                    actGridView.Rows[index].Cells[nameof(weightPointColumn)].Value = act.WeightPoint;
                    //int rowNum = actGridView.Rows.Add(row);
                    _fastAccess.Add(index, act.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                _console.AddException(ex);
                return false;
            }
        }

        public Guid GetMarked()
        {
            var index = actGridView?.CurrentRow?.Index ?? 0;
            return _fastAccess[index];
        }

        public bool UpdateData(ICollection<Act> data)
        {
            throw new NotImplementedException();
        }
    }
}
