using Appointment.Application.DTOs;

namespace Appointment.Application.Contracts;

public interface IAppointmentMapper
{
    AppointmentResponseDto ToResponseDto(Domain.Models.Appointment appointment);
    // List<AppointmentResponseDto> ToResponseDtos(List<Appointment> appointments);
}