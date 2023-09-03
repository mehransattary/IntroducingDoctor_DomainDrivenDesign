

using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.VisitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctor.Infrastructure.Persistent.Ef.VisitAgg;

public class VisitDay_Configuration : IEntityTypeConfiguration<VisitDay>
{
    public void Configure(EntityTypeBuilder<VisitDay> builder)
    {
        builder.ToTable("VisitDays", "visit");
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
        builder.HasMany(x => x.VisitTimes);
    }
}
