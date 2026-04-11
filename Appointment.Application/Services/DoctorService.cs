using Appointment.Application.Contracts;
using Appointment.Application.DTOs.DoctorDTos;

namespace Appointment.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IRepository<Domain.Models.Doctor> _doctorRepository;
    private readonly IDoctorMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    
    public async Task<Domain.Models.Doctor> CreateDoctor(CreateDoctorDto dto)
    {
        var doctor = _mapper.ToEntity(dto);
        _doctorRepository.Add(doctor);
        await _unitOfWork.CommitAsync();
        return doctor;
    }
}