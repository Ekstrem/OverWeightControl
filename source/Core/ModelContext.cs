using System.Data.Entity;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;

namespace OverWeightControl
{
    public class ModelContext : DbContext
    {
        [InjectionConstructor]
        public ModelContext(ISettingsStorage settings)
            : base(GetConnectionString(settings))
        {
            if (//settings == null ||
                bool.TryParse(settings?.Key(ArgsKeyList.IsDebugMode), out bool debug) &&
                debug)
                Database.Delete();
            Database.CreateIfNotExists();
        }

        private static string GetConnectionString(ISettingsStorage settings)
        {
            return settings?.Key(ArgsKeyList.ConnectionString)
                   ?? "Data Source=EHC\\SQLEXPRESS;Initial Catalog=ActsDB;Integrated Security=True";
            // ?? "Data Source=EWPCATMTL\\MSSQLSERVER2K8R2;Initial Catalog=ActsDB;Integrated Security=True"; //test value
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
                .HasKey(k => k.Id);
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
