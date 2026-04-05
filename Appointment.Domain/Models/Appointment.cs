using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Appointment
{
    public Guid Id { get; set; }
    
    public Guid PatientId { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public DateTime Date { get; set; }
    public Patient? Patient { get; set; }
}