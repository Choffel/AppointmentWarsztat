using Appointment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

   
    public DbSet<Patient> patients { get; set; }
    public DbSet<Domain.Models.Appointment> appointments { get; set; }
    public DbSet<Doctor> doctors { get; set; }
    public DbSet<Account> accounts { get; set; }
    public DbSet<MedicalResult> medicalResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Accounts"); 
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Email).IsRequired().HasMaxLength(255);
            entity.HasIndex(a => a.Email).IsUnique();
        }); 
        
        
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patients");
            entity.HasKey(e => e.Id);

            
            entity.HasOne(p => p.Account)
                .WithOne(a => a.PatientProfile) 
                .HasForeignKey<Patient>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            entity.HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        });

     
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctors");
            entity.HasKey(e => e.DoctorId);
            
            entity.HasOne(d => d.Account)
                .WithOne(a => a.DoctorProfile)
                .HasForeignKey<Doctor>(d => d.DoctorId) 
                .OnDelete(DeleteBehavior.Cascade);

            
            entity.HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); 
        });
        
        
        modelBuilder.Entity<Domain.Models.Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(a => a.Id);

            
            entity.Property(a => a.Date).IsRequired();
            entity.Property(a => a.StartTime).IsRequired();
            entity.Property(a => a.EndTime).IsRequired();

            
            entity.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            entity.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
        });

        modelBuilder.Entity<MedicalResult>(entity =>
        {
            entity.ToTable("MedicalResults");
            entity.HasKey(m => m.Id);
            entity.Property(m => m.TestName).IsRequired().HasMaxLength(120);
            entity.Property(m => m.Unit).IsRequired().HasMaxLength(32);
            entity.Property(m => m.PatientName).IsRequired().HasMaxLength(200);
            entity.Property(m => m.ProcessedAtUtc).IsRequired();
        });
    }
}