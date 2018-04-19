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
    public partial class WeighterControl :
        UserControl,
        IEditable<WeighterInfo>,
        IEditable<RawWeighterInfo>
    {
        private readonly IConsoleService _console;

        public WeighterControl()
        {
            InitializeComponent();
            BackColor = Color.Azure;
        }

        [InjectionConstructor]
        public WeighterControl(
            IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        #region IEditable<WeighterInfo> members

        public bool LoadData(WeighterInfo data)
        {
            try
            {
                weigherNumberTextBox.Text = data.WeigherNumber;
                verificationDatePicker.Value =
                    DateTime.Parse(data.VerificationDate);
                certificateNumberTextBox.Text = data.CertificateNumber;
                violatioNatureTextBox.Text = data.ViolationNature;
                // TODO: violationKoapComboBox
                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public WeighterInfo UpdateData()
        {
            try
            {
                var result = new WeighterInfo
                {
                    WeigherNumber = weigherNumberTextBox.Text,
                    VerificationDate = verificationDatePicker.Value.ToShortDateString(),
                    CertificateNumber = certificateNumberTextBox.Text,
                    ViolationNature = violatioNatureTextBox.Text
                };
                if (violationKoapComboBox.Items.Count > 0
                    && violationKoapComboBox.SelectedIndex != -1)
                {
                    result.ViolationKoap = violationKoapComboBox.SelectedValue.ToString();
                }

                return result;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        #endregion

        #region IEditable<RawWeighterInfo> members

        public bool LoadData(RawWeighterInfo data)
        {
            try
            {
                weigherNumberTextBox.Text = data.WeigherNumber.Value;
                verificationDatePicker.Value =
                    DateTime.Parse(data.VerificationDate.Value);
                certificateNumberTextBox.Text = data.CertificateNumber.Value;
                violatioNatureTextBox.Text = data.ViolationNature.Value;
                // TODO: violationKoapComboBox
                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        RawWeighterInfo IEditable<RawWeighterInfo>.UpdateData()
        {
            try
            {
                var result = new RawWeighterInfo
                {
                    WeigherNumber = new RecognizedValue(
                        weigherNumberTextBox.Text),
                    VerificationDate = new RecognizedValue(
                        verificationDatePicker.Value.ToShortDateString()),
                    CertificateNumber = new RecognizedValue(
                        certificateNumberTextBox.Text),
                    ViolationNature = new RecognizedValue(
                        violatioNatureTextBox.Text)
                };
                if (violationKoapComboBox.Items.Count > 0
                    && violationKoapComboBox.SelectedIndex != -1)
                {
                    result.ViolationKoap = new RecognizedValue(
                        violationKoapComboBox.SelectedValue.ToString());
                }

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
