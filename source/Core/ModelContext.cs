using System;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl
{
    public class ModelContext : DbContext
    {
        private readonly IConsoleService _console;

        [InjectionConstructor]
        public ModelContext(
            ISettingsStorage settings,
            IConsoleService console)
            : base(GetConnectionString(settings))
        {
            _console = console;

            try
            {
                Database.CreateIfNotExists();
            }
            catch (Exception e)
            {
                console.AddException(e);
            }
        }

        private static string GetConnectionString(ISettingsStorage settings)
        {
            return settings?[ArgsKeyList.ConnectionString]
                   ?? "Data Source=EHC\\SQLEXPRESS;Initial Catalog=ActsDB;Integrated Security=True";
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
