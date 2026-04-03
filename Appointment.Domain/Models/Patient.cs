using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Patient
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string Pesel { get; set; }

    public PatientStatus Status {get; set;}
}