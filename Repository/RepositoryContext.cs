using Entities.Models;
using Entities.Models.Appointments;
using Entities.Models.Items;
using Entities.Models.Movements;
using Entities.Models.Services;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    // staff tables
    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Nurse> Nurses { get; set; }

    // appointment
    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<AppointmentDoctor> AppointmentDoctors { get; set; }

    // items
    public DbSet<Item> Items { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<CategoryItem> CategoryItems { get; set; }

    public DbSet<Brand> Brands { get; set; }

    // movements
    public DbSet<Movement> Movements { get; set; }

    public DbSet<DetailMovement> DetailMovements { get; set; }

    // services
    public DbSet<Service> Services { get; set; }
    public DbSet<CategoryService> CategoryServices { get; set; }
    public DbSet<ServiceDoctor> ServiceDoctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>();
        modelBuilder.Entity<Patient>();
        modelBuilder.Entity<Nurse>();
        modelBuilder.Entity<Supplier>();
        modelBuilder.Entity<Appointment>();
        modelBuilder.Entity<AppointmentDoctor>();
        modelBuilder.Entity<Item>();
        modelBuilder.Entity<Unit>();
        modelBuilder.Entity<CategoryItem>();
        modelBuilder.Entity<Brand>();
        modelBuilder.Entity<Movement>();
        modelBuilder.Entity<DetailMovement>();
        modelBuilder.Entity<Service>();
        modelBuilder.Entity<CategoryService>();
        modelBuilder.Entity<ServiceDoctor>();
    }
}