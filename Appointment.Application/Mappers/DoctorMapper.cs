using Appointment.Application.Contracts;
using Appointment.Application.DTOs.DoctorDTos;
using Appointment.Domain.Models;

namespace Appointment.Application.Mappers;

public class DoctorMapper : IDoctorMapper
{
    public ResponseDoctorDto ToResponse(Doctor doctor)
    {
        return new ResponseDoctorDto(
            doctor.DoctorId,
            doctor.FirstName,
            doctor.LastName,
            doctor.Email,
            doctor.PhoneNumber,
            doctor.Specialty,
            doctor.Address,
            doctor.Sity); 
    }
    
}