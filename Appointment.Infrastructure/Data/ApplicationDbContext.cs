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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany<Domain.Models.Appointment>(q => q.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}