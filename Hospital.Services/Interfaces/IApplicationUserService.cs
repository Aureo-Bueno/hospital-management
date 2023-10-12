using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services.Interfaces;
public interface IApplicationUserService
{
    PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
    PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);
    PagedResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize);
    PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize);
}
