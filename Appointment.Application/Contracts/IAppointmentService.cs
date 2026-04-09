using Appointment.Application.DTOs;

namespace Appointment.Application.Contracts;

public interface IAppointmentService
{
    Task<AppointmentResponseDto> CreateAppointment(CreateAppointmentDto dto);
    
    Task<AppointmentResponseDto> GetAppointmentById(Guid patientId, Guid appointmentId);
    
     // Task<AppointmentResponseDto> ChangeAppointmentStatus(Guid patientId, Guid appointmentId, DateOnly date);
    
    Task<AppointmentResponseDto> DeleteAppointment(Guid patientId, Guid appointmentId);
}