

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.MedicalServicesAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctor.Infrastructure.Persistent.Ef.DoctorInformationAgg;

internal class DoctorInfo_Configuration : IEntityTypeConfiguration<DoctorInformation>
{
    public void Configure(EntityTypeBuilder<DoctorInformation> builder)
    {
        builder.ToTable("DoctorInformations", "doctorInfo");
        builder.HasKey(x => x.Id);
        builder.Property(b => b.FullName).IsRequired().HasMaxLength(250);
        builder.Property(b => b.ImageName).IsRequired().HasMaxLength(1000);
      
        builder.OwnsMany(x => x.Addresses, option => {
            option.ToTable("Addresses","doctorInfo");
            option.HasKey(b => b.Id);
            option.Property(x => x.TextAddress).IsRequired().HasMaxLength(500);
        });

        builder.OwnsMany(x => x.ContactNumbers, option => {
            option.ToTable("ContactNumbers", "doctorInfo");
            option.HasKey(b => b.Id);
            option.Property(x => x.Mobile).IsRequired().HasMaxLength(11);
        });
    }
}
