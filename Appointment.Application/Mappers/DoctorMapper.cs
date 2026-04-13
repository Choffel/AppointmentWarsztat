using Appointment.Application.Contracts;
using Appointment.Application.DTOs.DoctorDTos;
using Appointment.Domain.Models;

public class DoctorMapper : IDoctorMapper
{
    public ResponseDoctorDto ToResponse(Doctor doctor)
    {
        return new ResponseDoctorDto(
            doctor.DoctorId,
            doctor.Account.FirstName,  
            doctor.Account.LastName,   
            doctor.Account.Email,      
            doctor.Account.PhoneNumber,
            doctor.Specialty,          
            doctor.Address,            
            doctor.City                
        );
    }
}