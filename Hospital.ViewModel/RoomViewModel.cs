using Hospital.Models;

namespace Hospital.ViewModel;
public class RoomViewModel
{
    public Guid Id { get; set; }
    public string RoomNumber { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public Guid HospitalInfoId { get; set; }

    public RoomViewModel()
    { }

    public RoomViewModel(Room room)
    {
        Id = room.Id;
        RoomNumber = room.RoomNumber;
        Type = room.Type;
        Status = room.Status;
        HospitalInfoId = room.HospitalId;
    }

    public Room ConvertViewModel(RoomViewModel roomViewModel)
    {
        return new Room
        {
            Id = roomViewModel.Id,
            RoomNumber = roomViewModel.RoomNumber,
            Type = roomViewModel.Type,
            Status = roomViewModel.Status,
            HospitalId = roomViewModel.HospitalInfoId,
        };
    }
}
