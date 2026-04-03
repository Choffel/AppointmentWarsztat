using Appointment.Application.Contracts;
using Appointment.Domain.Models;
using Appointment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public PatientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Patient> GetById(Guid id)
    {
        // can use findAsync()
       return await _dbContext.patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Patient>> GetAll()
    {
        return await _dbContext.patients.ToListAsync();
    }

    public async Task<Patient> Add(Patient patient)
    {
        var add = await  _dbContext.patients.AddAsync(patient);
        
        return add.Entity;
    }

    public  async Task<Patient> Update(Patient patient)
    {
        var update = _dbContext.patients.Update(patient);
        
        return update.Entity;
    }
    

    public async Task DeleteAsync(Guid  patientId)
    {
        var patient = await _dbContext.patients.FirstOrDefaultAsync(p => p.Id == patientId);
        
        _dbContext.patients.Remove(patient);
    }
}