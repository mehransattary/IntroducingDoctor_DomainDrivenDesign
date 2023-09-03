

using Doctor.Domain.VisitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctor.Infrastructure.Persistent.Ef.VisitAgg;

public class VisitTime_Configuration : IEntityTypeConfiguration<VisitTime>
{
    public void Configure(EntityTypeBuilder<VisitTime> builder)
    {
        builder.ToTable("VisitTimes", "visit");
        builder.HasKey(x => x.Id);
        builder.Property(b => b.VisitDaysId).IsRequired();
        builder.Property(b => b.StartTime).IsRequired().HasMaxLength(50);
        builder.Property(b => b.EndTime).IsRequired().HasMaxLength(50);

    }
}
