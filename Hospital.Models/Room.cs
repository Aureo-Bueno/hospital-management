namespace Hospital.Models;
public class Room
{
    public Guid Id { get; set; }
    public string RoomNumber { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public Guid HospitalId { get; set; }
    public HospitalInfo Hospital { get; set; }
}