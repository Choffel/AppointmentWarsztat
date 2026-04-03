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
}