using Appointment.Application.DTOs.DoctorDTos;

namespace Appointment.Application.Contracts;

public class IDoctorService
{ 
    Task<ResponseDoctorDto> CreateAsync (CreateDoctorDto  dto);
    
    Task<ResponseDoctorDto> GetByIdAsync(Guid doctorId);
    
    Task<ResponseDoctorDto> UpdateAsync(Guid doctorId, UpdateDoctorDto dto);
    
    Task<bool> DeleteAsync(Guid doctorId);
}