﻿

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.MedicalServicesAgg;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infrastructure.Persistent.Ef;

public class DoctorContext : DbContext
{
   
    public DoctorContext(DbContextOptions<DoctorContext> options):base(options)   
    {
            
    }
    public DbSet<MedicalService> MedicalServices { get; set; }
    public DbSet<DoctorInformation> DoctorInformations { get; set; }

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