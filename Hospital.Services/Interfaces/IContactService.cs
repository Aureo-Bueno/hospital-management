using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services.Interfaces;
public interface IContactService
{
    PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
    ContactViewModel GetContactById(Guid id);
    void UpdateContactInfo(ContactViewModel contactViewModel);
    void InsertContact(ContactViewModel contactViewModel);
    void DeleteContact(Guid id);
}
