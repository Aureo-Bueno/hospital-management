using Hospital.Models;
using Hospital.Repositories.Interface;
using Hospital.Services.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services;
public class DoctorService : IDoctorService
{
    private IUnitOfWork _unitOfWork;
    public DoctorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void InsertTiming(TimingViewModel timingViewModel)
    {
        Timing? result = new TimingViewModel().ConvertViewModel(timingViewModel);
        _unitOfWork.Repository<Timing>().Add(result);
        _unitOfWork.Save();
    }

    public void DeleteTiming(Guid id)
    {
        Timing? result = _unitOfWork.Repository<Timing>().GetById(id);
        _unitOfWork.Repository<Timing>().Delete(result);
        _unitOfWork.Save();
    }

    public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
    {
        TimingViewModel timingViewModel = new();
        int totalCount;
        List<TimingViewModel> timingViewModels = new();

        try
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            List<Timing>? modelList = _unitOfWork.Repository<Timing>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.Repository<Timing>().GetAll().ToList().Count();

            timingViewModels = ConverModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }

        return new PagedResult<TimingViewModel>
        {
            Data = timingViewModels,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public IEnumerable<TimingViewModel> GetAll()
    {
        List<Timing>? result = _unitOfWork.Repository<Timing>().GetAll().ToList();
        return ConverModelToViewModelList(result);
    }

    public TimingViewModel GetTimingById(Guid id)
    {
        Timing result = _unitOfWork.Repository<Timing>().GetById(id);
        return new TimingViewModel(result);
    }

    public void UpdateTimingInfo(TimingViewModel timingViewModel)
    {
        Timing model = new TimingViewModel().ConvertViewModel(timingViewModel);
        var result = _unitOfWork.Repository<Timing>().GetById(model.Id);
        
        result.Id = model.Id;
        result.DoctorId = model.DoctorId;
        result.Status = model.Status;
        result.Duration = model.Duration;
        result.MorningShiftStartTime = model.MorningShiftStartTime;
        result.MorningShiftEndTime = model.MorningShiftEndTime;
        result.AfternoonShiftStartTime = model.AfternoonShiftStartTime;
        result.AfternoonShiftEndTime = model.AfternoonShiftEndTime;

        _unitOfWork.Repository<Timing>().Update(result);
        _unitOfWork.Save();

    }

    private List<TimingViewModel> ConverModelToViewModelList(List<Timing> timings)
    {
        return timings.Select(x => new TimingViewModel(x)).ToList();
    }
}
