namespace Appointment.Application.DTOs;

public record PatientResponse(
    Guid patientId,
    string patientName,
    string patientSurname,
    string patientEmail,
    string patientPhoneNumber,
    string patientGender,
    DateOnly patientDateOfBirth,
    string patientAddress,
    string patientCity,
    string pesel
    );