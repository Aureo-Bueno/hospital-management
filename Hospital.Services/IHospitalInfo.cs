using Hospital.ViewModel;
using Hospital.Utilities;

namespace Hospital.Services;
public interface IHospitalInfo
{
    PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
    HospitalInfoViewModel GetHospitalById(int id);
    void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);
    void InsertHospital(HospitalInfoViewModel hospitalInfo);
    void DeleteHospital(int id);
}
