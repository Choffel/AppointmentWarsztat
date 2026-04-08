using Appointment.Application.Contracts;
using Appointment.Application.DTOs;

namespace Appointment.Application.Mappers;

public class AppointmentMapper  : IAppointmentMapper
{
    public  AppointmentResponseDto ToResponseDto(Domain.Models.Appointment appointment)
    {
        return new AppointmentResponseDto(
            appointment.Id,
            appointment.Patient?.Name ?? "Unknown", // Безопасное обращение
            appointment.PatientId,
            appointment.Id, // Пока нет DoctorId — используем Id (заменить потом)
            "Dr. Smith", // TODO: добавить Doctor в модель
            appointment.Date,
            appointment.StartTime,
            appointment.EndTime,
            appointment.Status.ToString(),
            appointment.Description ?? ""
        );
    }
}