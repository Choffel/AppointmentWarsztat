using Appointment.Application.DTOs;
using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IPatientService
{
    Task<PatientResponse> Create(CreatePatientDto request);
    
    Task<PatientResponse> Update( Guid patientId, PatientUpdateDto request);
    
    Task Delete(Guid patientId);
    
    Task<PatientResponse> GetById(Guid id);
}