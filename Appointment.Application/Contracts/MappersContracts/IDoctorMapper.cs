using Appointment.Application.DTOs.DoctorDTos;

namespace Appointment.Application.Contracts;

public interface IDoctorMapper
{
    ResponseDoctorDto ToResponse(Domain.Models.Doctor doctor);
}