using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task<Doctor> GetByIdWithAccount(Guid id);
}