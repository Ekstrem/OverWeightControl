using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                
            var timerInterval = double.TryParse(
                settings[ArgsKeyList.WFProcWaitingFor], out var ti) ? ti : 3000;
            _timer = new Timer(timerInterval);

            InitializeComponent();

            InitControlEvents();

            _timer.Start();
        }

        private void InitControlEvents()
        {
            Disposed += (s, e) => _worker.CancelationToken = WorkFlowCancelationToken.Stoped;

            Load += (s, e) => LoadData(_worker.GetStatistic());

            Paint += (s, e) =>
            {
                if (_statistics.Status != TaskStatus.Running)
                {
                    if (_statistics.IsCompleted)
                        View(_statistics.Result);
                    LoadData(_worker.GetStatistic());
                }
            };

            _timer.Elapsed += (s, e) =>
            {
                try
                {
                    this.Invoke((Action)Refresh);
                }
                catch (Exception ex)
                {
                    _console.AddException(ex);
                }
            };
        }

        private Task<List<string>> LoadData(IDictionary<string, int> queue)
        {
            _statistics =  Task<List<string>>.Factory.StartNew(() =>
                queue.Select(i => $"{i.Key}: {i.Value}").ToList());
            return _statistics;
        }

        private void View(List<string> result)
        {
            listBox1.Items.Clear();
            result.ForEach(e => listBox1.Items.Add(e));
        }
    }
}
