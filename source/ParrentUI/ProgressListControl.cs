using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
        private readonly IUnityContainer _container;
        private readonly IWorkFlowProducerConsumer _worker;
        private readonly Timer _timer = new Timer(5000);

        [InjectionConstructor]
        public ProgressListControl(
            IUnityContainer container,
            IWorkFlowProducerConsumer worker)
        {
            _container = container;
            _worker = worker;
            worker?.WorkFlow();
            InitializeComponent();

            _timer.Elapsed += (s, e) => LoadData(
                _worker.GetStatistic());
            _timer.Start();
        }

        public void LoadData(IDictionary<string, int> queue)
        {
            var result = queue.Select(i => $"{i.Key}: {i.Value}").ToArray();
            
        }

        private void View(string[] result)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(result);
        }
    }
}
