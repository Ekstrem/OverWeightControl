using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using Unity;
using Unity.Attributes;
using Timer = System.Timers.Timer;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class ProgressListControl : UserControl
    {
        private const double _timerDelay = 5000;
        private readonly IUnityContainer _container;
        private readonly IWorkFlowProducerConsumer _worker;
        private readonly Timer _timer;
        private Task<List<string>> _statistics;

        [InjectionConstructor]
        public ProgressListControl(
            IUnityContainer container,
            IWorkFlowProducerConsumer worker)
        {
            _container = container;
            _worker = worker;
            worker?.WorkFlow();
            InitializeComponent();

            Paint += (s, e) =>
                View(LoadData(_worker.GetStatistic()).Result);

            _timer = new Timer(_timerDelay);
            Action action = Refresh;
            _timer.Elapsed += (s, e) =>
            {
                this.Invoke(action);
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
