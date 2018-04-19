using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity;

namespace OverWeightControl.Core.Settings
{
    public partial class EditorSettingsStorage :
        Form, IEditable<IDictionary<string, string>>
    {
        private readonly IConsoleService _console;
        private static IDictionary<string, string> _args;

        public EditorSettingsStorage(
            ISettingsStorage storage,
            IConsoleService console)
        {
            _console = console;
            _args = storage.GetArgs();

            InitializeComponent();

            dataGridView1.CellDoubleClick += (s, eArgs) =>
            {
                var rowNum = ((DataGridViewCellEventArgs) eArgs).RowIndex;
                if (dataGridView1.Rows[rowNum].Cells[0]
                    .Value.ToString().Contains("Path"))
                {
                    var folderDialog = new FolderBrowserDialog();
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.Rows[rowNum].Cells[1].Value =
                            folderDialog.SelectedPath;
                        dataGridView1.Update();
                    }
                    return;
                }

                if (dataGridView1.Rows[rowNum].Cells[0]
                    .Value.ToString().Contains("File"))
                {
                    var fileDialog = new OpenFileDialog {Multiselect = false};
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.Rows[rowNum].Cells[1].Value =
                            fileDialog.FileName;
                        dataGridView1.Update();
                    }
                    return;
                }
            };
        }

        public bool LoadData(IDictionary<string, string> data)
        {
            foreach (var key in _args.Keys)
                dataGridView1.Rows.Add(key, _args[key]);
            return true;
        }

        public IDictionary<string, string> UpdateData()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                        break;
                    var key = row.Cells[0].Value.ToString();
                    var value = row.Cells[1].Value.ToString();
                    if (!_args.ContainsKey(key))
                    {
                        _args.Add(key, value);
                        break;
                    }

                    if (_args[key] != value)
                    {
                        _args.Remove(key);
                        _args.Add(key, value);
                    }
                }

                return _args;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        public static void ShowModal(IUnityContainer container)
        {
            var form = container.Resolve<EditorSettingsStorage>();
            form.LoadData(_args);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.UpdateData();
            }
        }
    }
}
