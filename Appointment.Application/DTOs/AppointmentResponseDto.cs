namespace Appointment.Application.DTOs;

public record AppointmentResponseDto(
    Guid Id,
    string PatientName,
    Guid PatientId,
    Guid DoctorId,
    string DoctorName,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Status, 
    string Description
    );