using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Appointment
{
    public Guid Id { get; set; }
    
    public Guid PatientId { get; set; }
    
    public Guid DoctorId { get; set; }
    
    public string Description { get; set; }
    
    public TimeOnly StartTime { get; set; }
    
    public TimeOnly EndTime { get; set; }
    
    public DateOnly Date { get; set; }
    
    public Patient? Patient { get; set; }
    
    public Doctor? Doctor { get; set; }
    
    public AppointmentStatus Status { get; set; } =  AppointmentStatus.Pending;
    
}