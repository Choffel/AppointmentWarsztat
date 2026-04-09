namespace Appointment.Application.Contracts;

public interface IAppointmentChecker
{
    Task<bool> HasOverlappingAppointmentAsync(Guid doctorId, Guid appointmentId, DateOnly date, TimeOnly start, TimeOnly end);
}