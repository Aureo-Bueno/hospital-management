using Hospital.ViewModel;
using Hospital.Utilities;
using Hospital.Repositories.Interface;
using Hospital.Models;
using System.Linq;

namespace Hospital.Services;
public class HospitalInfoService : IHospitalInfo
{
    private IUnitOfWork _unitOfWork;
    public HospitalInfoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void DeleteHospital(int id)
    {
        HospitalInfo? result = _unitOfWork.Repository<HospitalInfo>().GetById(id);
        _unitOfWork.Repository<HospitalInfo>().Delete(result);
        _unitOfWork.Save();
    }

    public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
    {
        HospitalInfoViewModel hospitalInfoViewModel = new();
        int totalCount;
        List<HospitalInfoViewModel> hospitalInfoViewModels = new();

        try
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            List<HospitalInfo>? modelList = _unitOfWork.Repository<HospitalInfo>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.Repository<HospitalInfo>().GetAll().ToList().Count();

            hospitalInfoViewModels = ConverModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }

        return new PagedResult<HospitalInfoViewModel>
        {
            Data = hospitalInfoViewModels,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public HospitalInfoViewModel GetHospitalById(int id)
    {
        HospitalInfo? result = _unitOfWork.Repository<HospitalInfo>().GetById(id);
        HospitalInfoViewModel viewModel = new(result);

        return viewModel;
    }

    public void InsertHospital(HospitalInfoViewModel hospitalInfo)
    {
        HospitalInfo result = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
        _unitOfWork.Repository<HospitalInfo>().Add(result);
        _unitOfWork.Save();
    }

    public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
    {
        HospitalInfo result = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
        HospitalInfo resultById = _unitOfWork.Repository<HospitalInfo>().GetById(result.Id);

        resultById.Name = hospitalInfo.Name;
        resultById.City = hospitalInfo.City;
        resultById.PinCode = hospitalInfo.PinCode;
        resultById.Country = hospitalInfo.Country;
        _unitOfWork.Repository<HospitalInfo>().Update(resultById);
        _unitOfWork.Save();
    }

    private List<HospitalInfoViewModel> ConverModelToViewModelList(List<HospitalInfo> hospitalInfos)
    {
        return hospitalInfos.Select(x => new HospitalInfoViewModel(x)).ToList();
    }
}
