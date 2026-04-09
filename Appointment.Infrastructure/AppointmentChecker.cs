using System.Data.Entity;
using Appointment.Application.Contracts;

namespace Appointment.Infrastructure;

public class AppointmentChecker : IAppointmentChecker
{
    
    private readonly IRepository<Domain.Models.Appointment> _appointmentRepository;
    
    public AppointmentChecker(IRepository<Domain.Models.Appointment> appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    
    public async Task<bool> HasOverlappingAppointmentAsync(Guid doctorId, Guid appointmentId, DateOnly date, TimeOnly end, TimeOnly start)
    {
        var overlapping = await _appointmentRepository
            .GetQueryable()  
            .Where(a => a.DoctorId == doctorId &&
                        a.Id != appointmentId &&  
                        a.Date == date &&
                        (a.StartTime < end && a.EndTime > start))
            .FirstOrDefaultAsync();

        if (overlapping != null)
            throw new InvalidOperationException("Doctor is busy");
        
        return true;
    }
}