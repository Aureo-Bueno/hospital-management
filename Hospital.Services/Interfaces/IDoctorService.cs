using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services.Interfaces;
public interface IDoctorService
{
    PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);
    IEnumerable<TimingViewModel> GetAll();
    TimingViewModel GetTimingById(Guid id);
    void UpdateTimingInfo(TimingViewModel timingViewModel);
    void InsertTiming(TimingViewModel timingViewModel);
    void DeleteTiming(Guid id);
}
