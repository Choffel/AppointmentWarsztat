using Appointment.Application.DTOs;
using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IPatientMapper
{
    PatientResponse ToResponse(Patient patient);
   
}