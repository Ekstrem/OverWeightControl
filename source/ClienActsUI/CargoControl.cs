using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class CargoControl :
        UserControl, IEditable<CargoInfo>
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
        public CargoInfo UpdateData()
        {
            try
            {
                return new CargoInfo
                {
                    CargoCharacter = cargoCharacterTextBox.Text,
                    CargoType = cargoTypeTextBox.Text,
                    LegalWeight = float.Parse(legalWeightTextBox.Text),
                    ValetWeight = float.Parse(valetWeightTextBox.Text),
                    FactWeight = float.Parse(factWeightTextBox.Text),
                    PercentWeightOverflow = float.Parse(percentWeightOverflowTextBox.Text),
                    CargoSpecialAllow = float.Parse(cargoSpecialAllowTextBox.Text),
                    Tariffs = int.Parse(tariffsTextBox.Text),
                    LegLength = float.Parse(legLengthTextBox.Text),
                    RoadSection = roadSectionTextBox.Text,
                    Pass = passTextBox.Text,
                    OtherViolation = otherViolationTextBox.Text,
                    DriverExplanation = driverExplanationTextBox.Text
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
