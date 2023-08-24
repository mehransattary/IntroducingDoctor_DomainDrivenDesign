
using Doctor.Domain.MedicalServicesAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctor.Infrastructure.Persistent.Ef.MedicalServiceAgg;

internal class MedicalService_Configuration : IEntityTypeConfiguration<MedicalService>
{
    public void Configure(EntityTypeBuilder<MedicalService> builder)
    {
        builder.ToTable("MedicalServicies", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
        builder.Property(b => b.ShortDescription).IsRequired().HasMaxLength(500);
        builder.Property(b => b.Image).IsRequired().HasMaxLength(1000);
    }
}
