

using Common.Domain;
using Common.Domain.Exceptions;
using Doctor.Domain.MedicalServicesAgg.Services;

namespace Doctor.Domain.MedicalServicesAgg;

public class MedicalService : AggregateRoot
{
    #region Constructor
    private MedicalService()
    {

    }
    public MedicalService(string title, string shortDescription, string image)
    {
        Guard(title, shortDescription, image);
        this.Title = title;
        this.ShortDescription = shortDescription;
        this.Image = image;
    }
    #endregion

    #region Properties
    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Image { get; private set; }

    #endregion

    #region Methods
    public void Edit(string title, string shortDescription,string image)
    {
        Guard(title, shortDescription, image);

        this.Title = title;
        this.ShortDescription = shortDescription;
        this.Image = image; 
    }
    public void Guard(string title, string shortDescription, string image)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(shortDescription, nameof(shortDescription));
        NullOrEmptyDomainDataException.CheckString(image, nameof(image));

    }
    #endregion
}
