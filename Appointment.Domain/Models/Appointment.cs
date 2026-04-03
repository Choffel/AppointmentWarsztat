using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Appointment
{
    public Guid id { get; set; }
    
    public Guid PatientId { get; set; }
    
    public string PracitionerName { get; set;  }
    
    public AppointmentStatus Status { get; set;  }
}