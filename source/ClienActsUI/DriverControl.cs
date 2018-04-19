using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.RawData;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class DriverControl :
        UserControl,
        IEditable<DriverInfo>,
        IEditable<RawDriverInfo>
    {
        private readonly IConsoleService _console;

        public DriverControl()
        {
            InitializeComponent();
            BackColor = Color.Azure;
        }

        public DriverControl(
            IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        public bool LoadData(DriverInfo data)
        {
            try
            {
                fnMnSnameTextBox.Text = data.FnMnSname;
                driversLicenseNumberTextBox.Text = data.DriversLicenseNumber;
                operatorNameTextBox.Text = data.OperatorName;
                gibddNameTextBox.Text = data.GibddName;
                getingMarkTextBox.Text = data.GetingMark;
                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public bool LoadData(RawDriverInfo data)
        {
            try
            {
                fnMnSnameTextBox.Text = data.FnMnSname.Value;
                driversLicenseNumberTextBox.Text = data.DriversLicenseNumber.Value;
                operatorNameTextBox.Text = data.OperatorName.Value;
                gibddNameTextBox.Text = data.GibddName.Value;
                getingMarkTextBox.Text = data.GetingMark.Value;
                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        RawDriverInfo IEditable<RawDriverInfo>.UpdateData()
        {
            throw new NotImplementedException();
        }

        public DriverInfo UpdateData()
        {
            try
            {
                return new DriverInfo
                {
                    FnMnSname = fnMnSnameTextBox.Text,
                    DriversLicenseNumber = driversLicenseNumberTextBox.Text,
                    OperatorName = operatorNameTextBox.Text,
                    GibddName = gibddNameTextBox.Text,
                    GetingMark = getingMarkTextBox.Text
                };
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }
    }
}
