

using Common.Domain;
using Common.Domain.Exceptions;

namespace Doctor.Domain.DoctorInformationAgg;

public class ContactNumber : BaseEntity
{
    public ContactNumber(string mobile)
    {
        NullOrEmptyDomainDataException.CheckString(mobile, nameof(mobile));

        Mobile = mobile;
    }

    public long DoctorInformationId { get; internal set; }
    public string Mobile { get; private set; }
}
