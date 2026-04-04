namespace Appointment.Application.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}