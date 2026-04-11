namespace Appointment.Application.DTOs;

public record CreateAppointmentDto(
    Guid PatientId,
    Guid DoctorId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string? Description = null
    );