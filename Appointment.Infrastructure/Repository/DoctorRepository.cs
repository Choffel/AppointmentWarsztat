using System.Data.Entity;
using Appointment.Application.Contracts;
using Appointment.Domain.Models;
using Appointment.Infrastructure.Data;

namespace Appointment.Infrastructure.Repository;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    private readonly ApplicationDbContext _context;
    
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Doctor> GetByIdWithAccount(Guid id)
    {
        return await _context.doctors.Include(d => d.Account).FirstOrDefaultAsync(d => d.DoctorId == id);
    }
    
}