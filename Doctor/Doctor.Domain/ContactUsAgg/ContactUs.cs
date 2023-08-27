

using Common.Domain;
using Common.Domain.Exceptions;

namespace Doctor.Domain.ContactUsAgg;

public class ContactUs : AggregateRoot
{
    #region Constructor
    public ContactUs(string title, string imageName, string? description)
    {
        Title = title;
        ImageName = imageName;
        Description = description;
    }
    private ContactUs()
    {
    }
    #endregion

    #region Properties
    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string? Description { get; private set; }
    #endregion

    #region Methods
    public void Edit(string title, string imageName, string? description)
    {
        Title = title;
        ImageName = imageName;
        Description = description;
    }
    public void SetImage(string image)
    {
        NullOrEmptyDomainDataException.CheckString(image, nameof(image));
        ImageName = image;
    }
    private void Guard(string title, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
    #endregion
}
