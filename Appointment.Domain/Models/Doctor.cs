namespace Appointment.Domain.Models;

public class Doctor
{
    public Guid DoctorId { get; set; }
    
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Address { get; set; }
    
    public string Sity { get; set; }
    
    public string Specialty { get; set; }
    
    
    protected Doctor() { }
    
    public Doctor(string firstName, string lastName, string email, string phoneNumber, string specialty, string address, string sity)
    {
        DoctorId = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Specialty = specialty;
        Address = address;
        Sity = sity;
    }

    public void UpdateInfo(string firstName, string lastName, string email, string phoneNumber, string specialty, string address, string sity)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Specialty = specialty;
        Address = address;
        Sity = sity;
    }
}