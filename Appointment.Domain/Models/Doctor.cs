using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Doctor 
{
    
    public Guid DoctorId { get; set; }
    
    public string Specialty { get; set; }
    public string Address { get; set; }
    public string City { get; set; } 
    
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    
    
    public virtual Account Account { get; set; }
    
    protected Doctor() { }
    
    
    private Doctor(Guid accountId, string specialty, string address, string city)
    {
        DoctorId = accountId; 
        Specialty = specialty;
        Address = address;
        City = city;
    }

    public static (Account acc, Doctor doc) CreateWithAccount(
        string firstName, 
        string lastName, 
        string email,
        string phoneNumber, 
        string specialty, 
        string address, 
        string city, 
        string passwordHash)
    {
        var accountId = Guid.NewGuid();
        
        var acc = new Account
        {
            Id = accountId,
            Email = email,
            PasswordHash = passwordHash,
            Role = Role.Doctor,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        };
        

        var doc = new Doctor(accountId, specialty, address, city);
        
        return (acc, doc); 
    }


    public void UpdateInfo(string specialty, string address, string city)
    {
        Specialty = specialty;
        Address = address;
        City = city;
    }
}