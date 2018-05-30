using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Core.Settings
{
    public partial class EditorSettingsStorage :
        Form, IEditable<IDictionary<string, string>>
    {
        private readonly ISettingsStorage _settings;
        private readonly IConsoleService _console;
        private static IDictionary<string, string> _args;

        [InjectionConstructor]
        public EditorSettingsStorage(
            ISettingsStorage storage,
            [OptionalDependency] IConsoleService console)
        {
            _settings = storage;
            _console = console;

            InitializeComponent();

            InitEvents();

            LoadData(_args);
        }

        public bool LoadData(IDictionary<string, string> data)
        {
            foreach (var key in _args.Keys)
                dataGridView1.Rows.Add(key, _args[key]);
            return true;
        }

        public bool UpdateData(IDictionary<string, string> data)
        {
            try
            {
                if (data == null)
                {
                    data = new ConcurrentDictionary<string, string>();
                }

                data.Clear();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                        break;
                    data.Add(
                        row.Cells[0].Value.ToString(),
                        row.Cells[1].Value.ToString());
                }

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        public static void ShowModal(IUnityContainer container)
        {
            var form = container.Resolve<EditorSettingsStorage>();
            form.LoadData(_args);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.UpdateData(_args);
            }
        }

        private void InitEvents()
        {

            dataGridView1.CellDoubleClick += (s, eArgs) =>
            {
                try
                {
                    var rowNum = ((DataGridViewCellEventArgs)eArgs).RowIndex;
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
                        var fileDialog = new OpenFileDialog { Multiselect = false };
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            dataGridView1.Rows[rowNum].Cells[1].Value =
                                fileDialog.FileName;
                            dataGridView1.Update();
                        }

                        return;
                    }
                }
                catch (Exception ex)
                {
                    _console.AddException(ex);
                }
            };

            Closing += (s, e) =>
            {
                try
                {
                    if (DialogResult == DialogResult.OK
                        && UpdateData(_args))
                    {
                        _args.Keys
                            .ForEach(key => _settings[key] = _args[key]);
                        _settings.SaveToFile();
                    }
                }
                catch (Exception ex)
                {
                    _console.AddException(ex);
                }
            };
        }
    }
}
