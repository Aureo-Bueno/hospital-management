using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repositories;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<ApplicationUser> ApplicationUser {  get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<HospitalInfo> HospitalInfos { get; set; }
    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<Lab> Labs { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MedicineReport> MedicineReports { get; set; }
    public DbSet<PatientReport> PatientReports { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<TestPrice> TestPrices { get; set; }

}
