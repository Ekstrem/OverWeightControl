using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public partial class BroserForm : Form
    {
        public BroserForm()
        {
            InitializeComponent();
        }

        private BroserForm(
            IConsoleService console,
            string filename,
            string actNum)
        {
            InitializeComponent();
            Load += (s, e) =>
             {
                 try
                 {
                     webBrowser1.Navigate(filename);
                     console?.AddEvent($"{filename} opend in webBrowser.");
                 }
                 catch (Exception ex)
                 {
                     console?.AddException(ex);
                 }
             };
        }

        public static void ShowModal(
            IConsoleService console,
            string filename,
            string actNum)
        {
            using (var form = new BroserForm(console, filename, actNum))
            {
                form.ShowDialog();
            }
        }
    }
}
