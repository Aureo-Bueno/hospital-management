namespace Hospital.Models;
public class Contact
{
    public Guid Id { get; set; }
    public Guid HospitalId { get; set; }
    public HospitalInfo Hospital { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}