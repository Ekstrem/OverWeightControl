using System;
using System.Drawing;
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

        #region IEditable<DriverInfo> members

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

        public bool UpdateData(DriverInfo data)
        {
            try
            {
                data.FnMnSname = fnMnSnameTextBox.Text;
                data.DriversLicenseNumber = driversLicenseNumberTextBox.Text;
                data.OperatorName = operatorNameTextBox.Text;
                data.GibddName = gibddNameTextBox.Text;
                data.GetingMark = getingMarkTextBox.Text;

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        #endregion
        
        #region IEditable<DriverInfo> members

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

        public bool UpdateData(RawDriverInfo data)
        {
            try
            {
                data.FnMnSname = fnMnSnameTextBox.UpdateData();
                data.DriversLicenseNumber = driversLicenseNumberTextBox.UpdateData();
                data.OperatorName = operatorNameTextBox.UpdateData();
                data.GibddName = gibddNameTextBox.UpdateData();
                data.GetingMark = getingMarkTextBox.UpdateData();

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        #endregion

    }
}
