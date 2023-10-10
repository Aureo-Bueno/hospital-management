namespace Hospital.Models;
public class Medicine
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public ICollection<MedicineReport> MedicineReports { get; set; }
    public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
}
