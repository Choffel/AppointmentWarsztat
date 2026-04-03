using Appointment.Application.DTOs;
using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IPatientService
{
    Task<Patient> Create(Patient patient);
    
    Task<Patient> Update( Guid patientId, PatientUpdateDto request);
    
    Task<Patient> Delete(Guid patientId);
    
    Task<Patient> GetById(Guid id);
}