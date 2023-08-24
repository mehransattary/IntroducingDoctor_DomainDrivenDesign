

using Common.Domain;
using Common.Domain.Exceptions;

namespace Doctor.Domain.DoctorInformationAgg;

public class Specialization : BaseEntity
{
    public Specialization(string name)
    {
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        Name = name;
    }

    public long DoctorInformationId { get; internal set; }
    public string Name { get; private set; }
}
