using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IPatientRepository
{
    Task<Patient> GetById(Guid id);
    
    Task<List<Patient>> GetAll();
    
    Task<Patient> Add(Patient patient);
    
    Task<Patient> Update(Patient patient);
    
    Task Delete(Guid patientId);
    
}