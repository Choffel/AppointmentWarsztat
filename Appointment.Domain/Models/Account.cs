using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public abstract class Account
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    
    public virtual Doctor DoctorProfile { get; set; }
    
    public virtual Patient PatientProfile { get; set; }
}

