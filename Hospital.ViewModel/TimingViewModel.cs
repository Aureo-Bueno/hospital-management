using Hospital.Models;
using System.Web.Mvc;

namespace Hospital.ViewModel;
public class TimingViewModel
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

    List<SelectListItem> morningShiftStart = new();
    List<SelectListItem> morningShiftEnd = new();
    List<SelectListItem> afternoonShiftStart = new();
    List<SelectListItem> afternoonShiftEnd = new();

    public TimingViewModel()
    { }

    public TimingViewModel(Timing timing)
    {
        Id = timing.Id;
        Date = timing.Date;
        MorningShiftStartTime = timing.MorningShiftStartTime;
        MorningShiftEndTime = timing.MorningShiftEndTime;
        AfternoonShiftStartTime = timing.AfternoonShiftStartTime;
        AfternoonShiftEndTime = timing.AfternoonShiftEndTime;
        Duration = timing.Duration;
        Status = timing.Status;
        DoctorId = timing.DoctorId;
        Doctor = timing.Doctor;
    }

    public Timing ConvertViewModel(TimingViewModel timingViewModel)
    {
        return new Timing
        {
            Id = timingViewModel.Id,
            Date = timingViewModel.Date,
            MorningShiftStartTime = timingViewModel.MorningShiftStartTime,
            MorningShiftEndTime = timingViewModel.MorningShiftEndTime,
            AfternoonShiftStartTime = timingViewModel.AfternoonShiftStartTime,
            AfternoonShiftEndTime = timingViewModel.AfternoonShiftEndTime,
            Duration = timingViewModel.Duration,
            Status = timingViewModel.Status,
            DoctorId = timingViewModel.DoctorId,
            Doctor = timingViewModel.Doctor,
        };
    }

}
