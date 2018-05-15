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

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class ProgressListControl : UserControl
    {
        private readonly IUnityContainer _container;
        private readonly IWorkFlowProducerConsumer _worker;

        [InjectionConstructor]
        public ProgressListControl(
            IUnityContainer container,
            IWorkFlowProducerConsumer worker)
        {
            _container = container;
            _worker = worker;
            InitializeComponent();
        }

        public void LoadData(IDictionary<string, int> queue)
        {
            listBox1.Items.Clear();
            foreach (var i in queue)
                listBox1.Items.Add($"{i.Key}: {i.Value}");
        }
    }
}
