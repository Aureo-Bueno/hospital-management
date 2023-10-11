using Hospital.ViewModel;
using Hospital.Utilities;

namespace Hospital.Services.Interfaces;
public interface IHospitalInfo
{
    PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
    HospitalInfoViewModel GetHospitalById(Guid id);
    void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);
    void InsertHospital(HospitalInfoViewModel hospitalInfo);
    void DeleteHospital(Guid id);
}
