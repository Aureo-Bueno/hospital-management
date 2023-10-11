using Hospital.Models;
using Hospital.Repositories.Interface;
using Hospital.Services.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services;
public class ContactService : IContactService
{
    private IUnitOfWork _unitOfWork;

    public ContactService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void DeleteContact(Guid id)
    {
        Contact? result = _unitOfWork.Repository<Contact>().GetById(id);
        _unitOfWork.Repository<Contact>().Delete(result);
        _unitOfWork.Save();
    }

    public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
    {
        ContactViewModel contactViewModel = new();
        int totalCount;
        List<ContactViewModel> contactViewModels = new();

        try
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            List<Contact>? modelList = _unitOfWork.Repository<Contact>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.Repository<Contact>().GetAll().ToList().Count();

            contactViewModels = ConverModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }

        return new PagedResult<ContactViewModel>
        {
            Data = contactViewModels,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public ContactViewModel GetContactById(Guid id)
    {
        Contact? result = _unitOfWork.Repository<Contact>().GetById(id);
        ContactViewModel viewModel = new(result);

        return viewModel;
    }

    public void InsertContact(ContactViewModel contactViewModel)
    {
        Contact result = new ContactViewModel().ConvertViewModel(contactViewModel);
        _unitOfWork.Repository<Contact>().Add(result);
        _unitOfWork.Save();
    }

    public void UpdateContactInfo(ContactViewModel contactViewModel)
    {
        Contact result = new ContactViewModel().ConvertViewModel(contactViewModel);
        Contact resultById = _unitOfWork.Repository<Contact>().GetById(result.Id);

        resultById.Phone = contactViewModel.Phone;
        resultById.Email = contactViewModel.Email;
        resultById.HospitalId = contactViewModel.HospitalInfoId;
        _unitOfWork.Repository<Contact>().Update(resultById);
        _unitOfWork.Save();
    }

    private List<ContactViewModel> ConverModelToViewModelList(List<Contact> contacts)
    {
        return contacts.Select(x => new ContactViewModel(x)).ToList();
    }
}
