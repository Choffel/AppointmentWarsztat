using Appointment.Domain.Models;

namespace Appointment.Application.Contracts;

public interface IUnitOfWork : IDisposable
{
    IRepository<Patient> PatientRepository { get; } 
    
    IRepository<Domain.Models.Appointment> AppointmentRepository { get; }
    
    Task<int> CommitAsync();
}