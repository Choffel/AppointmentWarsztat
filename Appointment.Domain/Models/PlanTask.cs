namespace Appointment.Domain.Models;

public class PlanTask
{
    public Guid Id { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public string Status { get; set; } = "Scheduled";
}