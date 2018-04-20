using System;
using System.Globalization;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.RawData;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class ActControl : 
        UserControl,
        IEditable<Act>,
        IEditable<RawAct>
    {
        private readonly IUnityContainer _container;
        private readonly IConsoleService _console;

        public ActControl()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public ActControl(
            IUnityContainer container,
            IConsoleService console)
        {
            _container = container;
            _console = console;
            InitializeComponent();

            // digitsCheck = (s, e) => { }
        }

        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        public bool LoadData(Act data)
        {
            try
            {
                actNumberTextBox.LoadData(data.ActNumber);
                dateTimePicker.Value = DateTime.Parse(data.ActDateTime);
                ppvkNumberTextBox.LoadData(data.PpvkNumber);
                weightPointTextBox.LoadData(data.WeightPoint);
                weighterControl1.LoadData(data.Weighter);
                vehicleControl1.LoadData(data.Vehicle);
                vehicleDetailControl1.LoadData(data.Vehicle.Detail);
                cargoControl1.LoadData(data.Cargo);
                axisInfoControl1.LoadData(data.Cargo.Axises);
                driverControl1.LoadData(data.Driver);
                return true;
            }
            catch (FormatException fe)
            {
                _console.AddException(fe);
                return false;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public bool LoadData(RawAct data)
        {
            try
            {
                actNumberTextBox.LoadData(data.ActNumber);

                // date
                DateTime date;
                TimeSpan time;
                if (DateTime.TryParse(data.ActDate.Value, out date)
                    && TimeSpan.TryParse(data.ActTime.Value, out time))
                {
                    dateTimePicker.Value = date + time;
                }

                ppvkNumberTextBox.LoadData(data.PpvkNumber);
                weightPointTextBox.LoadData(data.WeightPoint);
                weighterControl1.LoadData(data.Weighter);
                vehicleControl1.LoadData(data.Vehicle);
                vehicleDetailControl1.LoadData(data.Vehicle.Detail);
                cargoControl1.LoadData(data.Cargo);
                axisInfoControl1.LoadData(data.Cargo.Axises);
                driverControl1.LoadData(data.Driver);
                return true;
            }
            catch (FormatException fe)
            {
                _console.AddException(fe);
                return false;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        RawAct IEditable<RawAct>.UpdateData()
        {
            try
            {
                // TODO: Исправить видимость перезагруженых методов
                var result = new RawAct
                {
                    ActNumber = actNumberTextBox.UpdateData(),

                    //ActDateTime = dateTimePicker.Value.ToString(CultureInfo.InvariantCulture),
                    PpvkNumber = ppvkNumberTextBox.UpdateData(),
                    WeightPoint = weightPointTextBox.UpdateData()
                    /*Weighter = weighterControl1.UpdateData(),
                    Vehicle = vehicleControl1.UpdateData(),
                    Cargo = cargoControl1.UpdateData(),
                    Driver = driverControl1.UpdateData()*/
                };

                /*result.Vehicle.Detail = vehicleDetailControl1.UpdateData();
                result.Cargo.Axises = axisInfoControl1.UpdateData();*/

                return result;
            }
            catch (FormatException fe)
            {
                _console.AddException(fe);
                return null;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        /// <summary>
        /// Получение данных из контрола после редактирования.
        /// </summary>
        /// <returns>Обновляемые данные.</returns>
        public Act UpdateData()
        {
            try
            {
                var result = new Act
                {
                    ActNumber = int.Parse(actNumberTextBox.Text),
                    ActDateTime = dateTimePicker.Value.ToString(CultureInfo.InvariantCulture),
                    PpvkNumber = int.Parse(ppvkNumberTextBox.Text),
                    WeightPoint = weightPointTextBox.Text,
                    Weighter = weighterControl1.UpdateData(),
                    Vehicle = vehicleControl1.UpdateData(),
                    Cargo = cargoControl1.UpdateData(),
                    Driver = driverControl1.UpdateData()
                };

                result.Vehicle.Detail = vehicleDetailControl1.UpdateData();
                result.Cargo.Axises = axisInfoControl1.UpdateData();

                return result;
            }
            catch (FormatException fe)
            {
                _console.AddException(fe);
                return null;
            }
            catch (NullReferenceException nre)
            {
                _console?.AddException(nre);
                return null;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }
    }
}
