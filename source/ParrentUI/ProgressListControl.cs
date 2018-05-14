using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverWeightControl.Clients.ParrentUI
{
    public partial class ProgressListControl : UserControl
    {
        public ProgressListControl()
        {
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
