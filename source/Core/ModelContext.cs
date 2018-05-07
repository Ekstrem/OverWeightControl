using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;

namespace OverWeightControl
{
    public class ModelContext : DbContext
    {
        [InjectionConstructor]
        public ModelContext(IUnityContainer container)
            : base(GetConnectionString(container))
        {
            Database.CreateIfNotExists();
        }

        private static string GetConnectionString(IUnityContainer container)
        {
            return container
                ?.Resolve<ISettingsStorage>()
                ?.Key(ArgsKeyList.ConnectionString)
                ?? "Data Source=EWPCATMTL\\MSSQLSERVER2K8R2;Initial Catalog=ActsDB;Integrated Security=True"; //test value
        }

        public DbSet<Act> Acts { get; set; }
        public DbSet<AxisInfo> Axises { get; set; }
        public DbSet<CargoInfo> Cargos { get; set; }
        public DbSet<DriverInfo> Drivers { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }
        public DbSet<VehicleInfo> Vehicles { get; set; }
        public DbSet<WeighterInfo> Weighters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Act>()
                .HasKey(k => k.Id)
                .ToTable("ActsTbl");
            modelBuilder.Entity<AxisInfo>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<CargoInfo>()
                .HasKey(k => k.Id)
                .HasMany(m => m.Axises);
            modelBuilder.Entity<DriverInfo>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<VehicleDetail>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<VehicleInfo>()
                .HasKey(k => k.Id)
                .HasMany(d => d.Detail);
            modelBuilder.Entity<WeighterInfo>()
                .HasKey(k => k.Id);
        }
    }
}
