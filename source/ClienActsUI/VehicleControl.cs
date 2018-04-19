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
        public VehicleInfo UpdateData()
        {
            try
            {
                var result = new VehicleInfo
                {
                    VehicleOwner = vehicleOwnerTextBox.Text,
                    VehicleCountry = vehicleCountryTextBox.Text,
                    VehicleSubjectCode = int.Parse(vehicleSubjectCodeTextBox.Text),
                    CarriageType = carriageTypeTextBox.Text,
                    VehicleRoute = vehicleRouteTextBox.Text,
                    FederalHighwaysDistance = federalHighwaysDistanceTextBox.Text,
                    VehicleShipper = vehicleShipperTextBox.Text
                };

                return result;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
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
        RawVehicleInfo IEditable<RawVehicleInfo>.UpdateData()
        {
            try
            {
                var result = new RawVehicleInfo
                {
                    VehicleOwner = new RecognizedValue(vehicleOwnerTextBox.Text),
                    VehicleCountry = new RecognizedValue(vehicleCountryTextBox.Text),
                    VehicleSubjectCode = new RecognizedValue(vehicleSubjectCodeTextBox.Text),
                    CarriageType = new RecognizedValue(carriageTypeTextBox.Text),
                    VehicleRoute = new RecognizedValue(vehicleRouteTextBox.Text),
                    FederalHighwaysDistance = new RecognizedValue(
                        federalHighwaysDistanceTextBox.Text),
                    VehicleShipper = new RecognizedValue(vehicleShipperTextBox.Text)
                };

                return result;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        #endregion
    }
}
