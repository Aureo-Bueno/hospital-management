using Hospital.Models;
using Hospital.Repositories.Interface;
using Hospital.Services.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services;
public class ApplicationUserService : IApplicationUserService
{
    private IUnitOfWork _unitOfWork;
    public ApplicationUserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
    {
        ApplicationUserViewModel viewModel = new();
        int totalCount;
        List<ApplicationUserViewModel> viewModelList = new();
        try
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            List<ApplicationUser> result = _unitOfWork.Repository<ApplicationUser>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.Repository<ApplicationUser>().GetAll().ToList().Count();

            viewModelList = ConvertModelToViewModelList(result);
        }
        catch (Exception)
        {

            throw;
        }

        return new PagedResult<ApplicationUserViewModel> 
        { 
            Data = viewModelList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize)
    {
        ApplicationUserViewModel viewModel = new();
        int totalCount;
        List<ApplicationUserViewModel> viewModelList = new();
        try
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            List<ApplicationUser> result = _unitOfWork.Repository<ApplicationUser>().GetAll(x => x.IsDoctor == true).Skip(excludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.Repository<ApplicationUser>().GetAll(x => x.IsDoctor == true).ToList().Count();

            viewModelList = ConvertModelToViewModelList(result);
        }
        catch (Exception)
        {

            throw;
        }

        return new PagedResult<ApplicationUserViewModel>
        {
            Data = viewModelList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public PagedResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> model)
    {
        return model.Select(x => new ApplicationUserViewModel(x)).ToList();
    }
}
