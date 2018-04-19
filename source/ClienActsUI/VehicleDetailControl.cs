using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OverWeightControl.Common.Model;
using OverWeightControl.Common.RawData;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using Unity.Attributes;

namespace OverWeightControl.Clients.ActsUI
{
    public partial class VehicleDetailControl :
        UserControl,
        IEditable<ICollection<VehicleDetail>>,
        IEditable<ICollection<RawVehicleDetail>>
    {
        private readonly IConsoleService _console;
        
        public VehicleDetailControl()
        {
            InitializeComponent();
            BackColor = Color.Azure;
        }

        [InjectionConstructor]
        public VehicleDetailControl(
            IConsoleService console)
        {
            _console = console;
            InitializeComponent();
        }

        #region IEditable<ICollection<VehicleDetail>> members

        public bool LoadData(ICollection<VehicleDetail> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var detail in data)
                {
                    dataGridView1.Rows.Add(
                        detail.VehicleType,
                        detail.VehicleBrand,
                        detail.VehicleModel,
                        detail.StateNumber);
                }

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        public ICollection<VehicleDetail> UpdateData()
        {
            try
            {
                return dataGridView1.Rows.Cast<DataGridViewRow>()
                    .TakeWhile(row => row.Cells[0].Value != null)
                    .Select(row => new VehicleDetail
                    {
                        VehicleType = row.Cells[0].Value.ToString(),
                        VehicleBrand = row.Cells[1].Value.ToString(),
                        VehicleModel = row.Cells[2].Value.ToString(),
                        StateNumber = row.Cells[3].Value.ToString()
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return null;
            }
        }

        #endregion

        #region IEditable<ICollection<RawVehicleDetail>> members

        public bool LoadData(ICollection<RawVehicleDetail> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var detail in data)
                {
                    dataGridView1.Rows.Add(
                        detail.VehicleType.Value,
                        detail.VehicleBrand.Value,
                        detail.VehicleModel.Value,
                        detail.StateNumber.Value);
                }

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
            }
        }

        ICollection<RawVehicleDetail> IEditable<ICollection<RawVehicleDetail>>.UpdateData()
        {
            try
            {
                return dataGridView1.Rows.Cast<DataGridViewRow>()
                    .TakeWhile(row => row.Cells[0].Value != null)
                    .Select(row => new RawVehicleDetail
                    {
                        VehicleType = new RecognizedValue(
                            row.Cells[0].Value.ToString()),
                        VehicleBrand = new RecognizedValue(
                            row.Cells[1].Value.ToString()),
                        VehicleModel = new RecognizedValue(
                            row.Cells[2].Value.ToString()),
                        StateNumber = new RecognizedValue(
                            row.Cells[3].Value.ToString())
                    })
                    .ToList();
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
