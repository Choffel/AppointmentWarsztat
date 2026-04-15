using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IDoctorRepository
{
    Task<Doctor> GetByIdWithAccount(Guid id);
}