using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;
using Timer = System.Timers.Timer;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class ProgressListControl : UserControl
    {
        private readonly IConsoleService _console;
        private readonly IUnityContainer _container;
        private readonly IWorkFlowProducerConsumer _worker;
        private readonly Timer _timer;
        private Task<List<string>> _statistics;

        [InjectionConstructor]
        public ProgressListControl(
            IConsoleService console,
            ISettingsStorage settings,
            IUnityContainer container,
            IWorkFlowProducerConsumer worker)
        {
            _console = console;
            _container = container;
            _worker = worker;
            worker?.WorkFlow();
            InitializeComponent();

            Disposed += (s, e) => _worker.CancelationToken = WorkFlowCancelationToken.Stoped;

            Paint += (s, e) =>
                View(LoadData(_worker.GetStatistic()).Result);

            var timerInterval = double.TryParse(
                settings[ArgsKeyList.WFProcWaitingFor], out var ti) ? ti : 3000;
            _timer = new Timer(timerInterval);
            Action action = Refresh;
            _timer.Elapsed += (s, e) =>
            {
                try
                {
                this.Invoke(action);
                }
                catch (Exception ex)
                {
                    _console.AddException(ex);
                }
            };

            _timer.Start();
        }

        private Task<List<string>> LoadData(IDictionary<string, int> queue)
        {
            return Task<List<string>>.Factory.StartNew(() =>
                queue.Select(i => $"{i.Key}: {i.Value}").ToList());
        }

        private void View(List<string> result)
        {
            listBox1.Items.Clear();
            result.ForEach(e => listBox1.Items.Add(e));
        }
    }
}
