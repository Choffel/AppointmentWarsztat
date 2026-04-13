namespace Appointment.Application.DTOs.DoctorDTos;

public record CreateDoctorDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Specialty,
    string Address,
    string City,
    string Password
    );
