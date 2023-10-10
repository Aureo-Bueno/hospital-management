using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models;
public class Appointment
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Description { get; set; }
    public ApplicationUser Doctor { get; set; }
    public ApplicationUser Patient { get; set; }
}