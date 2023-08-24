using Doctor.Domain.MedicalServicesAgg;

namespace Doctor.Domain.Test.Unit.MedicalServiceAgg.Builders;

internal class MedicalServiceBuilder
{
    private string _title;
    private string _shortDescription;
    private string _image;

    public MedicalServiceBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }
    public MedicalServiceBuilder SetShortDescription(string shortDescription)
    {
        _shortDescription = shortDescription;
        return this;
    }
    public MedicalServiceBuilder SetImage(string image)
    {
        _image = image;
        return this;
    }
    public MedicalService Build()
    {
        return new MedicalService(_title, _shortDescription, _image);
    }
}