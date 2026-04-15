using System.Data.Entity;
using Appointment.Domain.Models;
using Appointment.Application.Contracts;
using Appointment.Infrastructure.Data;

namespace Appointment.Infrastructure.Repository;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    private readonly ApplicationDbContext _context;


    public PatientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public  async Task<Patient> GetByIdWitchAccountAsync(Guid id)
    {
        return await _context.patients
            .Include(p => p.Account)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}