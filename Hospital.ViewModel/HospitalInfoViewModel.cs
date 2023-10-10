using Hospital.Models;

namespace Hospital.ViewModel;
public class HospitalInfoViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string City { get; set; }
    public string PinCode { get; set; }
    public string Country { get; set; }

    public HospitalInfoViewModel()
    { }

    public HospitalInfoViewModel(HospitalInfo hospitalInfo)
    {
        Id = hospitalInfo.Id;
        Name = hospitalInfo.Name;
        Type = hospitalInfo.Type;
        City = hospitalInfo.City;
        PinCode = hospitalInfo.PinCode;
        Country = hospitalInfo.Country;
    }

    public HospitalInfo ConvertViewModel(HospitalInfoViewModel hospitalInfoViewModel)
    {
        return new HospitalInfo
        {
            Id = hospitalInfoViewModel.Id,
            Name = hospitalInfoViewModel.Name,
            Type = hospitalInfoViewModel.Type,
            City = hospitalInfoViewModel.City,
            PinCode = hospitalInfoViewModel.PinCode,
            Country = hospitalInfoViewModel.Country,
        };
    }
}
