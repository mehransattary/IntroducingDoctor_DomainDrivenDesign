
using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.DoctorInformationAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctor.Infrastructure.Persistent.Ef.AboutUsAgg;

internal class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
{
    public void Configure(EntityTypeBuilder<AboutUs> builder)
    {
        builder.ToTable("AboutUs", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
        builder.Property(b => b.ImageName).IsRequired().HasMaxLength(1000);
    }
}
