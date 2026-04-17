using Appointment.Application.Contracts;
using Appointment.Application.DTOs;

namespace Appointment.Application.Mappers;

public class AppointmentMapper  : IAppointmentMapper
{
    public  AppointmentResponseDto ToResponseDto(Domain.Models.Appointment appointment)
    {
        string patientName = $"{appointment.Patient?.Account?.FirstName} {appointment.Patient?.Account?.LastName}".Trim();
        if (string.IsNullOrWhiteSpace(patientName)) patientName = "Unknown Patient";

        string doctorName = $"Dr. {appointment.Doctor?.Account?.LastName}".Trim();
        if (doctorName == "Dr.") doctorName = "Unknown Doctor";

        return new AppointmentResponseDto(
            appointment.Id,
            patientName, 
            appointment.PatientId,
            appointment.DoctorId, 
            doctorName, 
            appointment.Date,
            appointment.StartTime,
            appointment.EndTime,
            appointment.Status.ToString(),
            appointment.Description ?? ""
        );
    }
}