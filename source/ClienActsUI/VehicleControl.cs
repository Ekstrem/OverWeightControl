using System;
using System.Drawing;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.RawData;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class VehicleControl : 
        UserControl,
        IEditable<VehicleInfo>,
        IEditable<RawVehicleInfo>
    {
        private readonly IConsoleService _console;

        public VehicleControl()
        {
            InitializeComponent();
            BackColor = Color.Azure;
        }

        public VehicleControl(
            [OptionalDependency]IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        #region IEditable<VehicleInfo> members

        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        public bool LoadData(VehicleInfo data)
        {
            try
            {
                vehicleOwnerTextBox.Text = data.VehicleOwner;
                vehicleCountryTextBox.Text = data.VehicleCountry;
                vehicleSubjectCodeTextBox.Text = data.VehicleSubjectCode.ToString();
                carriageTypeTextBox.Text = data.CarriageType;
                vehicleRouteTextBox.Text = data.VehicleRoute;
                federalHighwaysDistanceTextBox.Text = data.FederalHighwaysDistance;
                vehicleShipperTextBox.Text = data.VehicleShipper;

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        /// <summary>
        /// Получение данных из контрола после редактирования.
        /// </summary>
        /// <returns>Обновляемые данные.</returns>
        public bool UpdateData(VehicleInfo data)
        {
            try
            {
                data.VehicleOwner = vehicleOwnerTextBox.Text;
                data.VehicleCountry = vehicleCountryTextBox.Text;
                data.VehicleSubjectCode = int.Parse(vehicleSubjectCodeTextBox.Text);
                data.CarriageType = carriageTypeTextBox.Text;
                data.VehicleRoute = vehicleRouteTextBox.Text;
                data.FederalHighwaysDistance = federalHighwaysDistanceTextBox.Text;
                data.VehicleShipper = vehicleShipperTextBox.Text;

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        #endregion

        #region IEditable<RawVehicleInfo> members

        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        public bool LoadData(RawVehicleInfo data)
        {
            try
            {
                vehicleOwnerTextBox.Text = data.VehicleOwner.Value;
                vehicleCountryTextBox.Text = data.VehicleCountry.Value;
                vehicleSubjectCodeTextBox.Text = data.VehicleSubjectCode.Value;
                carriageTypeTextBox.Text = data.CarriageType.Value;
                vehicleRouteTextBox.Text = data.VehicleRoute.Value;
                federalHighwaysDistanceTextBox.Text = data.FederalHighwaysDistance.Value;
                vehicleShipperTextBox.Text = data.VehicleShipper.Value;

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        /// <summary>
        /// Получение данных из контрола после редактирования.
        /// </summary>
        /// <returns>Обновляемые данные.</returns>
        public bool UpdateData(RawVehicleInfo data)
        {
            try
            {
                data.VehicleOwner = vehicleOwnerTextBox.UpdateData();
                data.VehicleCountry = vehicleCountryTextBox.UpdateData();
                data.VehicleSubjectCode = vehicleSubjectCodeTextBox.UpdateData();
                data.CarriageType = carriageTypeTextBox.UpdateData();
                data.VehicleRoute = vehicleRouteTextBox.UpdateData();
                data.FederalHighwaysDistance = federalHighwaysDistanceTextBox.UpdateData();
                data.VehicleShipper = vehicleShipperTextBox.UpdateData();

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
