using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OverWeightControl.Common.BelModel;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class ValidatioinControl : UserControl
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private readonly IWorkFlowProducerConsumer _consumer;
        private readonly IUnityContainer _container;
        private readonly ModelContext _context;
        private readonly Dictionary<string, FileTransferInfo> _items;

        public ValidatioinControl()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public ValidatioinControl(
            IConsoleService console,
            ISettingsStorage settings,
            IWorkFlowProducerConsumer consumer,
            IUnityContainer container,
            DbContext context)
        {
            _consumer = consumer;
            _container = container;
            _context = (ModelContext)context;
            _console = console;
            _settings = settings;
            console.AddEvent($"{nameof(ValidatioinControl)} created.");

            InitializeComponent();

            _items = new Dictionary<string, FileTransferInfo>();
        }

        public void LoadData()
        {
            while (_consumer.TryTake(out var fti))
            {
                listBox1.Items.Add($"{fti}");
                _items.Add(fti.ToString(), fti);
            }
        }

        public string LoadJsonFile()
        {
            try
            {
                if (listBox1.SelectedIndex == -1)
                return String.Empty;
            var item = listBox1.Items[listBox1.SelectedIndex].ToString();
            var data = _items[item].Data;
            return Encoding.UTF8.GetString(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return string.Empty;
            }
        }

        public void Work()
        {
            var form = (ActEditForm)_container.Resolve<Form>("ActEditForm");
            var act = _settings.GetArgs().ContainsKey(ArgsKeyList.Mode)
                      && _settings.Key(ArgsKeyList.Mode).Equals("Act")
                ? new Act().LoadFromJson(LoadJsonFile())
                : BlankList.GetList(LoadJsonFile(), ex =>
                    _console?.AddException(ex)).ToModelFormat(e => _console?.AddException(e));
            if (ActEditForm.ShowModal(_container, act) == null) return;

            _context.Acts.Add(act);
            _context.SaveChanges();

            var item = listBox1.Items[listBox1.SelectedIndex].ToString();
            var storeFileName = $"{_settings.Key(ArgsKeyList.StorePath)}\\{_items[item].Id}";
            File.Delete(storeFileName);
            _items.Remove(item);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
