namespace Appointment.Application.DTOs;

public record CreatePatientDto(string FirstName, string LastName, DateTime DateOfBirth, string Pesel);