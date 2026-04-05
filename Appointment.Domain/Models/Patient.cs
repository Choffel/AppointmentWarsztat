using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Patient : EventArgs
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string Pesel { get; set; }
    
    
    private readonly List<Appointment> _appointments = new List<Appointment>();
    
    
    public IReadOnlyCollection<Appointment> Appointments => _appointments;

    public PatientStatus Status {get; set;}
}