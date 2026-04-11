namespace Appointment.Application.DTOs.DoctorDTos;

public record CreateDoctorDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string Specialty,
    string Address,
    string City);
