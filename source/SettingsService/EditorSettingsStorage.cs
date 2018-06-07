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
        Form, IEditable<ISettingsStorage>
    {
        private readonly ISettingsStorage _settings;
        private readonly IConsoleService _console;
        private static IDictionary<string, string> _args;

        [InjectionConstructor]
        public EditorSettingsStorage(
            ISettingsStorage settings,
            [OptionalDependency] IConsoleService console)
        {
            _settings = settings;
            _console = console;

            InitializeComponent();

            InitEvents();

            LoadData(settings);
        }

        public bool LoadData(ISettingsStorage data)
        {
            if (data == null)
                data = _settings;
            foreach (var key in data.GetKeys())
                dataGridView1.Rows.Add(key, data[key]);
            return true;
        }

        public bool UpdateData(ISettingsStorage data)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                        break;
                    _settings[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
                }

                _settings.SaveToFile();
                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        public static void ShowModal(IUnityContainer container, ISettingsStorage settings)
        {
            var form = container.Resolve<EditorSettingsStorage>();
            form.LoadData(settings);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.UpdateData(settings);
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
                        && UpdateData(_settings))
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
