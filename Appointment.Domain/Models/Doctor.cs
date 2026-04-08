namespace Appointment.Domain.Models;

public abstract class Doctor
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Address { get; set; }
    
    public string Sity { get; set; }
    
    public string Specialty { get; set; }
}