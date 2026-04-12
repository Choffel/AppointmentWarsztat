using Appointment.Domain.Enums;

namespace Appointment.Domain.Models;

public class Patient : EventArgs
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    
    public string Pesel { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string Gender { get; set; }
    
    private readonly List<Appointment> _appointments = new List<Appointment>();
    
    
    public IReadOnlyCollection<Appointment> Appointments => _appointments;

    public PatientStatus Status {get; set;}
    
    
    protected Patient(){}

    public Patient(Guid id, string name, string surname, DateOnly dateOfBirth, string pesel, string email,
        string phoneNumber, string address, string city, string gender)
    {
        Id = id;
        FirstName = name;
        LastName = surname;
        DateOfBirth = dateOfBirth;
        Pesel = pesel;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        City = city;
        Gender = gender;
    }


    public void UpdateInfo(string name, string surname, DateOnly dateOfBirth, string pesel, string email,
        string phoneNumber, string address, string city, string gender)
    {
        FirstName = name;
        LastName = surname;
        DateOfBirth = dateOfBirth;
        Pesel = pesel;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        City = city;
        Gender = gender;
    }
}