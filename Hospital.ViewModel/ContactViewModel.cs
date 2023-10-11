using Hospital.Models;

namespace Hospital.ViewModel;
public class ContactViewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid HospitalInfoId { get; set; }

    public ContactViewModel()
    { }

    public ContactViewModel(Contact contact)
    {
        Id = contact.Id;
        Email = contact.Email;
        Phone = contact.Phone;
        HospitalInfoId = contact.HospitalId;
    }

    public Contact ConvertViewModel(ContactViewModel viewModel)
    {
        return new Contact
        {
            Id = viewModel.Id,
            Email = viewModel.Email,
            Phone = viewModel.Phone,
            HospitalId = viewModel.HospitalInfoId
        };
    }
}
