using System.Globalization;
using System.Windows.Forms;
using OverWeightControl.Common.RawData;

namespace OverWeightControl.Clients.ActsUI
{
    internal static class DataLoader
    {
        internal static void Load(
            this TextBox control, RecognizedValue value) => 
            control.Text = value.Value;

        internal static void Load(
            this TextBox control, string value) => control.Text = value;
        internal static void Load(
            this TextBox control, int value) => control.Text = value.ToString();
        internal static void Load(
            this TextBox control, double value) =>
            control.Text = value.ToString(CultureInfo.CurrentCulture);
        internal static void Load(
            this TextBox control, float value) =>
            control.Text = value.ToString(CultureInfo.CurrentCulture);


        internal static RecognizedValue Update(this TextBox control)
        {
            return new RecognizedValue(control.Text);
        }

    }
}