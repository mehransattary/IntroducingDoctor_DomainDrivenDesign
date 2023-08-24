using Common.Domain;
using Common.Domain.Exceptions;

namespace Doctor.Domain.DoctorInformationAgg;

public class Address : BaseEntity
{
    public Address(string textAddress, string codePosti)
    {
        NullOrEmptyDomainDataException.CheckString(textAddress, nameof(textAddress));

        TextAddress = textAddress;
        CodePosti = codePosti;
    }

    public long DoctorInformationId { get; internal set; }
    public string TextAddress { get; private set; }
    public string? CodePosti { get; private set; }

}