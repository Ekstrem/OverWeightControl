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
using Unity.Interception.Utilities;

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

        public bool UpdateData(ICollection<VehicleDetail> data)
        {
            try
            {
                if (data == null)
                {
                    data = new List<VehicleDetail>();
                }

                data.Clear();

                dataGridView1.Rows.Cast<DataGridViewRow>()
                    .TakeWhile(row => row.Cells[0].Value != null)
                    .Select(row => new VehicleDetail
                    {
                        VehicleType = row.Cells[0].Value.ToString(),
                        VehicleBrand = row.Cells[1].Value.ToString(),
                        VehicleModel = row.Cells[2].Value.ToString(),
                        StateNumber = row.Cells[3].Value.ToString()
                    })
                    .ForEach(data.Add);

                return true;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return false;
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

        public bool UpdateData(ICollection<RawVehicleDetail> data)
        {
            try
            {
                if (data == null)
                {
                    data = new List<RawVehicleDetail>();
                }

                data.Clear();
                dataGridView1.Rows.Cast<DataGridViewRow>()
                    .TakeWhile(row => row.Cells[0].Value != null)
                    .Select(row => new RawVehicleDetail
                    {
                        VehicleType = row.UpdateData(0),
                        VehicleBrand = row.UpdateData(1),
                        VehicleModel = row.UpdateData(2),
                        StateNumber = row.UpdateData(3)
                    })
                    .ForEach(data.Add);
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
