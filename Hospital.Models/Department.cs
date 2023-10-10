namespace Hospital.Models;
public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ApplicationUser> Employees { get; set; }
}
