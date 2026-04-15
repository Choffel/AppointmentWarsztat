using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IPatientRepository
{
    Task<Patient> GetByIdWitchAccountAsync(Guid id);
}