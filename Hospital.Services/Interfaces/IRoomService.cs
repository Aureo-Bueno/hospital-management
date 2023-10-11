using Hospital.Utilities;
using Hospital.ViewModel;

namespace Hospital.Services.Interfaces;
public interface IRoomService
{
    PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
    RoomViewModel GetRoomById(Guid id);
    void UpdateRoom(RoomViewModel roomViewModel);
    void InsertRoom(RoomViewModel roomViewModel);
    void DeleteRoom(Guid id);
}
