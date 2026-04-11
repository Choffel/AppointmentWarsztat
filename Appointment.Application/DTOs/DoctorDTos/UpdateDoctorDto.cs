namespace Appointment.Application.DTOs.DoctorDTos;

public record UpdateDoctorDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Specialty,
    string Address,
    string City);
