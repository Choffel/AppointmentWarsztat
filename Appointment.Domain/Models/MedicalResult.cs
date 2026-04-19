using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class MedicalResult
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string TestName { get; set; }
    
    public double Value { get; set; }
    
    public string Unit { get; set; }
    
    public MedicalStatus Status { get; set; }
    
    public string PatientName { get; set; } = "Unknown Patient";

    public DateTime ProcessedAtUtc { get; set; } = DateTime.UtcNow;
}