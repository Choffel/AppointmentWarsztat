namespace Appointment.Application.DTOs;

public record CreatePatientDto(
    string FirstName, string LastName, DateOnly DateOfBirth, string Pesel, string Email, string PhoneNumber, string Address, string City, string Gender,string Password);