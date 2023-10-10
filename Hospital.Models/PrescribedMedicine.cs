namespace Hospital.Models;
public class PrescribedMedicine
{
    public Guid Id { get; set; }
    public Medicine Medicine { get; set; }
    public PatientReport PatientReport { get; set; }
}
