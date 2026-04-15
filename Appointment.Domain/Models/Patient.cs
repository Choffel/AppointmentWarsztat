using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Patient 
{
    
    public Guid Id { get; set; }
    
    
    public DateOnly DateOfBirth { get; set; }
    public string Pesel { get; set; }
    public string Gender { get; set; }
    public PatientStatus Status { get; set; }
    
    public string Address { get; set; }
    public string City { get; set; }
    
    
    public virtual Account Account { get; set; }
    
    private readonly List<Appointment> _appointments = new List<Appointment>();
    public virtual IReadOnlyCollection<Appointment> Appointments => _appointments;
    
    protected Patient() { }

    
    public Patient(Guid id, DateOnly dateOfBirth, string pesel, string address, string city, string gender)
    {
        Id = id;
        DateOfBirth = dateOfBirth;
        Pesel = pesel;
        Address = address;
        City = city;
        Gender = gender;
        Status = PatientStatus.Active; 
    }

    
    public static (Account acc, Patient pat) CreateWithAccount(
        string firstName, 
        string lastName, 
        string email,
        string phoneNumber, 
        DateOnly dateOfBirth, 
        string pesel, 
        string address, 
        string city, 
        string gender, 
        string passwordHash)
    {
        var accountId = Guid.NewGuid();

        var acc = new Account
        {
            Id = accountId,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
            Role = Role.Patient
        };
        
        var pat = new Patient(accountId, dateOfBirth, pesel, address, city, gender);
        
        return (acc, pat);
    }

    public void UpdateInfo(DateOnly dateOfBirth, string pesel, string address, string city, string gender)
    {
        DateOfBirth = dateOfBirth;
        Pesel = pesel;
        Address = address;
        City = city;
        Gender = gender;
    }
}