using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class AxisInfoControl :
        UserControl, IEditable<ICollection<AxisInfo>>
    {
        private IConsoleService _console;

        public AxisInfoControl()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public AxisInfoControl(
            IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка данных в контрол.
        /// </summary>
        /// <param name="data">Обновляемые данные.</param>
        public bool LoadData(ICollection<AxisInfo> data)
        {
            try
            {
                var axisCount = data?.Count ?? 12;
                axisCountTextBox.Text = axisCount.ToString();

                dataGridView1.Rows.Clear();
                for (int i = 0; i < int.Parse(axisCountTextBox.Text); i++)
                {
                    dataGridView1.Rows.Add();
                }

                foreach (var axle in data)
                {
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[0].Value = axle.AxisNum;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[1].Value = axle.AxisStinginess;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[2].Value = axle.SuspentionType;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[3].Value = axle.Distance2NextAxis;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[4].Value = axle.MeasuredAsisWeight;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[5].Value = axle.LegalAxisWeight;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[6].Value = axle.SpecialAllow;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[7].Value = axle.UsedAxisAllow;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[8].Value = axle.WeightRecordedExcess;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[9].Value = axle.PercentRecordedExcess;
                    dataGridView1.Rows[int.Parse(axle.AxisNum) - 1].Cells[10].Value = axle.Overweight;
                }
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
        public ICollection<AxisInfo> UpdateData()
        {
            try
            {
                var result = new List<AxisInfo>();
                foreach (var row in dataGridView1.Rows)
                {
                    var axle = new AxisInfo
                    {
                        AxisNum = ((DataGridViewRow) row).Cells[0].Value.ToString(),
                        AxisStinginess = (int)((DataGridViewRow)row).Cells[1].Value,
                        SuspentionType = ((DataGridViewRow)row).Cells[2].Value.ToString(),
                        Distance2NextAxis = (int)((DataGridViewRow)row).Cells[3].Value,
                        MeasuredAsisWeight = (float)((DataGridViewRow)row).Cells[4].Value,
                        LegalAxisWeight = (float)((DataGridViewRow)row).Cells[5].Value,
                        SpecialAllow = (float)((DataGridViewRow)row).Cells[6].Value,
                        UsedAxisAllow = (float)((DataGridViewRow)row).Cells[7].Value,
                        WeightRecordedExcess = (float)((DataGridViewRow)row).Cells[8].Value,
                        PercentRecordedExcess = (float)((DataGridViewRow)row).Cells[9].Value,
                        Overweight = ((DataGridViewRow)row).Cells[10].Value.ToString()
                    };
                    result.Add(axle);
                }

                return result;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }
    }
}
