namespace Hospital.Models;
public class Timing
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public ApplicationUser Doctor { get; set; }
    public DateTime Date { get; set; }
    public int MorningShiftStartTime { get; set; }
    public int MorningShiftEndTime { get; set; }
    public int AfternoonShiftStartTime { get; set; }
    public int AfternoonShiftEndTime { get; set; }
    public int Duration { get; set; }
    public Status Status { get; set; }

}
