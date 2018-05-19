using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
        private const int _timerDelay = 15000;
        private readonly IUnityContainer _container;
        private readonly IWorkFlowProducerConsumer _worker;
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
            
        }

        private Task<List<string>> LoadData(IDictionary<string, int> queue)
        {
            //Thread.Sleep(1000);
            return Task<List<string>>.Factory.StartNew(() =>
                queue.Select(i => $"{i.Key}: {i.Value}").ToList());
        }

        private void View(List<string> result)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(items: result.ToArray());
        }
    }
}
