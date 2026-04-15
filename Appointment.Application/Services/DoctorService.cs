using Appointment.Application.Contracts;
using Appointment.Application.DTOs.DoctorDTos;
using Appointment.Domain.Models;

namespace Appointment.Application.Services;

public class DoctorService : IDoctorService
{
    
    private readonly IDoctorRepository _doctorRepository;
    private readonly IRepository<Account> _accountRepository;
    private readonly IDoctorMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(
        IDoctorRepository doctorRepository, 
        IRepository<Account> accountRepository, 
        IDoctorMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _accountRepository = accountRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDoctorDto> CreateAsync(CreateDoctorDto dto)
    {
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        
        var (account, doctor) = Doctor.CreateWithAccount(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber,
            dto.Specialty,
            dto.Address,
            dto.City,
            passwordHash
        );
        
        
        _accountRepository.Add(account);
        _doctorRepository.Add(doctor);
        
        await _unitOfWork.CommitAsync();

        
        return _mapper.ToResponse(doctor);
    }
    
    public async Task<ResponseDoctorDto> UpdateAsync(Guid doctorId, UpdateDoctorDto dto)
    {
       
        var existing = await _doctorRepository.GetByIdWithAccount(doctorId);

        if (existing == null)
            throw new Exception("Doctor not found");

        
        existing.UpdateInfo(
            specialty: dto.Specialty,
            address: dto.Address,
            city: dto.City
        );
        
        await _unitOfWork.CommitAsync();

        return _mapper.ToResponse(existing);
    }

    public async Task<bool> DeleteAsync(Guid doctorId)
    {
       
       await _doctorRepository.Delete(doctorId);
       await _unitOfWork.CommitAsync();

       return true;
    }
    
    public async Task<ResponseDoctorDto> GetByIdAsync(Guid doctorId)
    {
        
        var doctor = await _doctorRepository.GetByIdWithAccount(doctorId);

        if (doctor == null)
            throw new Exception("Doctor not found");

        return _mapper.ToResponse(doctor);
    }
}