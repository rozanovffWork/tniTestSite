using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using tniTestSite.Data.Models;

namespace tniTestSite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; }
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
        public DbSet<EstimatedMeteringDevice> EstimatedMeteringDevices { get; set; }


        public DbSet<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }
        public DbSet<ElectricEnergyMeter> ElectricEnergyMeters { get; set; }
        public DbSet<PowerTransformer> PowerTransformers { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformer { get; set; }

        public DbSet<TimeSet> TimeSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubsidiaryOrganization>()
                .HasOne(p => p.HeadOrganization)
                .WithMany(b => b.SubsidiaryOrganizations)
                .HasForeignKey(p => p.HeadOrganizationId);

            modelBuilder.Entity<ConsumptionObject>()
                .HasOne(p => p.Organization)
                .WithMany(b => b.ConsumptionObjects)
                .HasForeignKey(p => p.OrganizationId);

            modelBuilder.Entity<ElectricitySupplyPoint>()
                .HasOne(p => p.ConsumptionObject)
                .WithMany(b => b.ElectricitySupplyPoints)
                .HasForeignKey(p => p.ConsumptionObjectId);

            modelBuilder.Entity<ElectricitySupplyPoint>()
                .HasOne(p => p.ConsumptionObject)
                .WithMany(b => b.ElectricitySupplyPoints)
                .HasForeignKey(p => p.ConsumptionObjectId);

            modelBuilder.Entity<ElectricitySupplyPoint>()
                .HasOne(p => p.ConsumptionObject)
                .WithMany(b => b.ElectricitySupplyPoints)
                .HasForeignKey(p => p.ConsumptionObjectId);

            modelBuilder.Entity<EstimatedMeteringDevice>()
                .HasOne(p => p.ElectricitySupplyPoint)
                .WithMany(b => b.EstimatedMeteringDevices)
                .HasForeignKey(p => p.ElectricitySupplyPointId);
            //===============
            modelBuilder.Entity<ElectricityMeasurementPoint>()
                .HasOne(p => p.ConsumptionObject)
                .WithMany(b => b.ElectricityMeasurementPoints)
                .HasForeignKey(p => p.ConsumptionObjectId);

            modelBuilder.Entity<ElectricityMeasurementPoint>()
                .HasOne(p => p.ElectricEnergyMeter)
                .WithOne(b => b.ElectricityMeasurementPoint)
                .HasForeignKey<ElectricEnergyMeter>(b => b.ElectricityMeasurementPointId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ElectricityMeasurementPoint>()
                .HasOne(p => p.PowerTransformer)
                .WithOne(b => b.ElectricityMeasurementPoint)
                .HasForeignKey<PowerTransformer>(b => b.ElectricityMeasurementPointId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ElectricityMeasurementPoint>()
                .HasOne(p => p.VoltageTransformer)
                .WithOne(b => b.ElectricityMeasurementPoint)
                .HasForeignKey<VoltageTransformer>(b => b.ElectricityMeasurementPointId)
                .OnDelete(DeleteBehavior.Cascade);

            //==================

            modelBuilder.Entity<TimeSet>()
                .HasKey(t => new { t.ElectricityMeasurementPointId, t.EstimatedMeteringDeviceId });

            


            modelBuilder.Entity<TimeSet>()
                .HasOne(p => p.ElectricityMeasurementPoint)
                .WithMany(b => b.TimeSets)
                .HasForeignKey(p => p.ElectricityMeasurementPointId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeSet>()
                .HasOne(p => p.EstimatedMeteringDevice)
                .WithMany(b => b.TimeSets)
                .HasForeignKey(p => p.EstimatedMeteringDeviceId);
        }
    }
}
