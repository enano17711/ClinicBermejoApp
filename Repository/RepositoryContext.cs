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
    // staff
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Nurse> Nurses { get; set; }
    // appointment
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentDoctor> AppointmentDoctors { get; set; }
    // items
    public DbSet<Item> Items { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<UnitBase> UnitBases { get; set; }
    public DbSet<CategoryItem> CategoryItems { get; set; }
    public DbSet<CategoryItemMN> CategoryItemMNs { get; set; }
    public DbSet<ItemUnit> ItemUnits { get; set; }
    public DbSet<Brand> Brands { get; set; }
    // movements
    public DbSet<Movement> Movements { get; set; }
    public DbSet<DetailMovement> DetailMovements { get; set; }
    public DbSet<Note> Notes { get; set; }
    // services
    public DbSet<Service> Services { get; set; }
    public DbSet<CategoryService> CategoryServices { get; set; }
    public DbSet<ServiceDoctor> ServiceDoctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>();
        modelBuilder.Entity<Supplier>();
        // Staff
        modelBuilder.Entity<Doctor>();
        modelBuilder.Entity<Nurse>();
        // Appointment
        modelBuilder.Entity<Appointment>();
        modelBuilder.Entity<AppointmentDoctor>();
        // Items
        modelBuilder.Entity<Item>();
        modelBuilder.Entity<UnitBase>();
        modelBuilder.Entity<Unit>().HasMany(u => u.Items).WithMany(i => i.Units).UsingEntity<ItemUnit>();
        modelBuilder.Entity<ItemUnit>();
        modelBuilder.Entity<CategoryItem>().HasMany(ci => ci.Items).WithMany(i => i.CategoryItems)
            .UsingEntity<CategoryItemMN>();
        modelBuilder.Entity<CategoryItemMN>();
        modelBuilder.Entity<Brand>();
        // Movements
        modelBuilder.Entity<Movement>();
        modelBuilder.Entity<DetailMovement>();
        modelBuilder.Entity<Note>();
        // Services
        modelBuilder.Entity<Service>();
        modelBuilder.Entity<CategoryService>();
        modelBuilder.Entity<ServiceDoctor>();
    }
}