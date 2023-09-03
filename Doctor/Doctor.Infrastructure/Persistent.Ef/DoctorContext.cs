

using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.ContactUsAgg;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.VisitAgg;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infrastructure.Persistent.Ef;

public class DoctorContext : DbContext
{
   
    public DoctorContext(DbContextOptions<DoctorContext> options):base(options)   
    {
            
    }
    public DbSet<MedicalService> MedicalServices { get; set; }
    public DbSet<DoctorInformation> DoctorInformations { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<VisitDay> VisitDays { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
