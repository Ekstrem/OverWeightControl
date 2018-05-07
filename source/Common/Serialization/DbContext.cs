using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverWeightControl.Common.Model;

namespace OverWeightControl.Common.Serialization
{
    public class Context : DbContext
    {
        // public DbSet<Act> Acts { get; set; }
        // public DbSet<AxisInfo> Axises { get; set; }
        // public DbSet<CargoInfo> Cargos { get; set; }
        // public DbSet<DriverInfo> Drivers { get; set; }
        // public DbSet<VehicleDetail> VehicleDetails { get; set; }
        // public DbSet<VehicleInfo> Vehicles { get; set; }
        // public DbSet<WeighterInfo> Weighters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
