namespace Hospital.Models;
public class Insurance
{
    public Guid Id { get; set; }
    public string PolicyNumber { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public ICollection<Bill> Bill { get; set; }
}
