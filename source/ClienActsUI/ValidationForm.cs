using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class ValidationForm : Form
    {
        private readonly IUnityContainer _container;

        public ValidationForm()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public ValidationForm(IUnityContainer container)
        {
            _container = container;
            InitializeComponent();
        }

        private void validateBtn_Click(object sender, EventArgs e) => validatioinControl1.Work();

        private void updateBtn_Click(object sender, EventArgs e) => validatioinControl1.LoadData();
    }
}
