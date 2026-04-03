using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Appointment
{
    public Guid Id { get; set; }
    
    public Guid PatientId { get; set; }
    
    public DateTime Date { get; set; }
}