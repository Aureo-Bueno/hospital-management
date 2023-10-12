using Hospital.Models;

namespace Hospital.ViewModel;
public class ApplicationUserViewModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string City { get; set; }
    public Gender Gender { get; set; }
    public bool IsDoctor { get; set; }
    public string Specialist { get; set; }

    public ApplicationUserViewModel()
    { }

    public ApplicationUserViewModel(ApplicationUser applicationUser)
    {
        Name = applicationUser.Name;
        City = applicationUser.City;
        Gender = applicationUser.Gender;
        IsDoctor = applicationUser.IsDoctor;
        Specialist = applicationUser.Specialist;
        UserName = applicationUser.UserName;
        Email = applicationUser.Email;
    }

    public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel applicationUserViewModel)
    {
        return new ApplicationUser
        {
            Name = applicationUserViewModel.Name,
            City = applicationUserViewModel.City,
            Gender = applicationUserViewModel.Gender,
            IsDoctor = applicationUserViewModel.IsDoctor,
            Specialist = applicationUserViewModel.Specialist,
            UserName = applicationUserViewModel.UserName,
            Email = applicationUserViewModel.Email
        };
    }
    public List<ApplicationUserViewModel> Doctors { get; set; } = new();
}
