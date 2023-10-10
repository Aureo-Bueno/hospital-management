namespace Hospital.Models;
public class PatientReport
{
    public Guid Id { get; set; }
    public string Diagnose { get; set; }
    public ApplicationUser Doctor { get; set; }
    public ApplicationUser Patient { get; set; }
    public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
}
