using Appointment.Domain.Models;

namespace Appointment.Application.DTOs;

public record DoctorsListDto(IEnumerable<Doctor> Doctors);