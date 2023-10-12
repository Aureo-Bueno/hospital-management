using Hospital.Models;
using Hospital.Repositories.Interface;
using Hospital.Services.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services;
public class RoomService : IRoomService
{
    private IUnitOfWork _unitOfWork;

    public RoomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void DeleteRoom(Guid id)
    {
        Room result = _unitOfWork.Repository<Room>().GetById(id);
        _unitOfWork.Repository<Room>().Delete(result);
        _unitOfWork.Save();
    }

    public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
    {
        RoomViewModel roomViewModel = new();
        int totalCount;
        List<RoomViewModel> roomViewModels = new();

        try
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            List<Room>? modelList = _unitOfWork.Repository<Room>().GetAll(includeProperties:"Hospital").Skip(ExcludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.Repository<Room>().GetAll().ToList().Count();

            roomViewModels = ConverModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }

        return new PagedResult<RoomViewModel>
        {
            Data = roomViewModels,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public RoomViewModel GetRoomById(Guid id)
    {
        Room? result = _unitOfWork.Repository<Room>().GetById(id);
        RoomViewModel viewModel = new(result);

        return viewModel;
    }

    public void InsertRoom(RoomViewModel roomViewModel)
    {
        Room result = new RoomViewModel().ConvertViewModel(roomViewModel);
        _unitOfWork.Repository<Room>().Add(result);
        _unitOfWork.Save();
    }

    public void UpdateRoom(RoomViewModel roomViewModel)
    {
        Room result = new RoomViewModel().ConvertViewModel(roomViewModel);
        Room resultById = _unitOfWork.Repository<Room>().GetById(result.Id);

        resultById.Type = roomViewModel.Type;
        resultById.RoomNumber = roomViewModel.RoomNumber;
        resultById.Status = roomViewModel.Status;
        resultById.HospitalId = roomViewModel.HospitalInfoId;
        _unitOfWork.Repository<Room>().Update(resultById);
        _unitOfWork.Save();
    }

    private List<RoomViewModel> ConverModelToViewModelList(List<Room> rooms)
    {
        return rooms.Select(x => new RoomViewModel(x)).ToList();
    }
}
