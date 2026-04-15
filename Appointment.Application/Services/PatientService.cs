using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Appointment.Domain.Models;


namespace Appointment.Application.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IRepository<Patient> _repository;
    private readonly IRepository<Account> _accountRepository;
    private readonly IPatientRepository _patientRepository;
    
    private readonly IPatientMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IPatientMapper mapper, IRepository<Patient> repository, IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PatientResponse> Create(CreatePatientDto dto)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        
        var (account, patient) = Patient.CreateWithAccount(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber,
            dto.DateOfBirth,
            dto.Pesel,
            dto.Address,
            dto.City,
            dto.Gender,
            passwordHash
        );
        
       
        _accountRepository.Add(account);
        _repository.Add(patient);

        await _unitOfWork.CommitAsync();
    
        
        return _mapper.ToResponse(patient);
    }

    public async Task<PatientResponse> Update(Guid patientId, PatientUpdateDto request)
    {
        
        var existing = await _patientRepository.GetByIdWitchAccountAsync(patientId);

        if (existing == null)
        {
            throw new Exception("Patient not found");
        }
    
        
        existing.Account.FirstName = request.Name;
        existing.Account.LastName = request.Surname;
        
        
        // existing.UpdateInfo(
        //     request.DateOfBirth,
        //     request.Pesel,
        //     request.Address,
        //     request.City,
        //     request.Gender
        // );
    
        await _unitOfWork.CommitAsync();
    
        return _mapper.ToResponse(existing);
    }

    public async Task Delete(Guid patientId)
    {
        await _repository.Delete(patientId);
        
        await _unitOfWork.CommitAsync();
    }

    public async Task<PatientResponse> GetById(Guid id)
    {
        var result = await _repository.GetById(id);

        if (result == null)
        {
            throw new Exception("Patient not found");
        }
        
        return _mapper.ToResponse(result);
    }
}