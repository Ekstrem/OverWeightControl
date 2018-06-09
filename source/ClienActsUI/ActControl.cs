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

        #region IEditeble<Acts> members

        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        public bool LoadData(Act data)
        {
            try
            {
                actNumberTextBox.LoadData(data.ActNumber);
                dateTimePicker.Value =data.ActDateTime;
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

        /// <summary>
        /// Получение данных из контрола после редактирования.
        /// </summary>
        /// <returns>Обновляемые данные.</returns>
        public bool UpdateData(Act data)
        {
            try
            {
                data.ActNumber = int.Parse(actNumberTextBox.Text);
                data.ActDateTime = dateTimePicker.Value;
                data.PpvkNumber = int.Parse(ppvkNumberTextBox.Text);
                data.WeightPoint = weightPointTextBox.Text;
                weighterControl1.UpdateData(data.Weighter);
                vehicleControl1.UpdateData(data.Vehicle);
                cargoControl1.UpdateData(data.Cargo);
                driverControl1.UpdateData(data.Driver);
                vehicleDetailControl1.UpdateData(data.Vehicle.Detail);
                axisInfoControl1.UpdateData(data.Cargo.Axises);

                return true;
            }
            catch (FormatException fe)
            {
                _console.AddException(fe);
                return false;
            }
            catch (NullReferenceException nre)
            {
                _console?.AddException(nre);
                return false;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        #endregion

        #region IEditeble<RawActs> members

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

        public bool UpdateData(RawAct data)
        {
            try
            {
                data.ActNumber = actNumberTextBox.UpdateData();
                data.ActDate = new RecognizedValue(
                    dateTimePicker.Value.ToShortDateString());
                data.ActTime = new RecognizedValue(
                    dateTimePicker.Value.ToShortTimeString());
                data.PpvkNumber = ppvkNumberTextBox.UpdateData();
                data.WeightPoint = weightPointTextBox.UpdateData();
                weighterControl1.UpdateData(data.Weighter);
                vehicleControl1.UpdateData(data.Vehicle);
                cargoControl1.UpdateData(data.Cargo);
                driverControl1.UpdateData(data.Driver);
                vehicleDetailControl1.UpdateData(data.Vehicle.Detail);
                axisInfoControl1.UpdateData(data.Cargo.Axises);

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

        #endregion

    }
}
