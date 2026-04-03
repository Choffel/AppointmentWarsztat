using Appointment.Application.DTOs;
using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IPatientService
{
    Task<Patient> Create(CreatePatientDto request);
    
    Task<Patient> Update( Guid patientId, PatientUpdateDto request);
    
    Task Delete(Guid patientId);
    
    Task<Patient> GetById(Guid id);
}