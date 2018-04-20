using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.RawData;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class CargoControl :
        UserControl,
        IEditable<CargoInfo>,
        IEditable<RawCargoInfo>
    {
        private readonly IConsoleService _console;

        public CargoControl()
        {
            InitializeComponent();
            BackColor = Color.Azure;
        }

        [InjectionConstructor]
        public CargoControl(
            IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        #region IEditeble<CargoInfo> members

        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        public bool LoadData(CargoInfo data)
        {
            try
            {
                cargoCharacterTextBox.Text = data.CargoCharacter;
                cargoTypeTextBox.Text = data.CargoType;
                legalWeightTextBox.Text = data.LegalWeight
                    .ToString(CultureInfo.CurrentCulture);
                valetWeightTextBox.Text = data.ValetWeight
                    .ToString(CultureInfo.CurrentCulture);
                factWeightTextBox.Text = data.FactWeight
                    .ToString(CultureInfo.CurrentCulture);
                percentWeightOverflowTextBox.Text = data.PercentWeightOverflow
                    .ToString(CultureInfo.CurrentCulture);
                cargoSpecialAllowTextBox.Text = data.CargoSpecialAllow
                    .ToString(CultureInfo.CurrentCulture);
                tariffsTextBox.Text = data.Tariffs
                    .ToString(CultureInfo.CurrentCulture);
                legLengthTextBox.Text = data.LegLength
                    .ToString(CultureInfo.CurrentCulture);
                roadSectionTextBox.Text = data.RoadSection;
                passTextBox.Text = data.Pass;
                otherViolationTextBox.Text = data.OtherViolation;
                driverExplanationTextBox.Text = data.DriverExplanation;

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
        public bool UpdateData(CargoInfo data)
        {
            try
            {
                data.CargoCharacter = cargoCharacterTextBox.Text;
                data.CargoType = cargoTypeTextBox.Text;
                data.LegalWeight = float.Parse(legalWeightTextBox.Text);
                data.ValetWeight = float.Parse(valetWeightTextBox.Text);
                data.FactWeight = float.Parse(factWeightTextBox.Text);
                data.PercentWeightOverflow = float.Parse(percentWeightOverflowTextBox.Text);
                data.CargoSpecialAllow = float.Parse(cargoSpecialAllowTextBox.Text);
                data.Tariffs = int.Parse(tariffsTextBox.Text);
                data.LegLength = float.Parse(legLengthTextBox.Text);
                data.RoadSection = roadSectionTextBox.Text;
                data.Pass = passTextBox.Text;
                data.OtherViolation = otherViolationTextBox.Text;
                data.DriverExplanation = driverExplanationTextBox.Text;

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        #endregion

        #region IEditeble<RawCargoInfo> members

        public bool LoadData(RawCargoInfo data)
        {
            try
            {
                cargoCharacterTextBox.LoadData(data.CargoCharacter);
                cargoTypeTextBox.LoadData(data.CargoType);
                legalWeightTextBox.LoadData(data.LegalWeight);
                valetWeightTextBox.LoadData(data.ValetWeight);
                factWeightTextBox.LoadData(data.FactWeight);
                percentWeightOverflowTextBox.LoadData(data.PercentWeightOverflow);
                cargoSpecialAllowTextBox.LoadData(data.CargoSpecialAllow);
                tariffsTextBox.LoadData(data.Tariffs);
                legLengthTextBox.LoadData(data.LegLength);
                roadSectionTextBox.LoadData(data.RoadSection);
                passTextBox.LoadData(data.Pass);
                otherViolationTextBox.LoadData(data.OtherViolation);
                driverExplanationTextBox.LoadData(data.DriverExplanation);

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public bool UpdateData(RawCargoInfo data)
        {
            try
            {
                data.CargoCharacter = cargoCharacterTextBox.UpdateData();
                data.CargoType = cargoTypeTextBox.UpdateData();
                data.LegalWeight = legalWeightTextBox.UpdateData();
                data.ValetWeight = valetWeightTextBox.UpdateData();
                data.FactWeight = factWeightTextBox.UpdateData();
                data.PercentWeightOverflow = percentWeightOverflowTextBox.UpdateData();
                data.CargoSpecialAllow = cargoSpecialAllowTextBox.UpdateData();
                data.Tariffs = tariffsTextBox.UpdateData();
                data.LegLength = legLengthTextBox.UpdateData();
                data.RoadSection = roadSectionTextBox.UpdateData();
                data.Pass = passTextBox.UpdateData();
                data.OtherViolation = otherViolationTextBox.UpdateData();
                data.DriverExplanation = driverExplanationTextBox.UpdateData();

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
