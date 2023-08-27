
using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.ContactUsAgg;
using Doctor.Domain.DoctorInformationAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctor.Infrastructure.Persistent.Ef.ContactUsAgg;

internal class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
{
    public void Configure(EntityTypeBuilder<ContactUs> builder)
    {
        builder.ToTable("ContactUs", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
        builder.Property(b => b.ImageName).IsRequired().HasMaxLength(1000);
    }
}
