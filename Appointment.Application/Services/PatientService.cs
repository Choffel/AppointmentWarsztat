using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Appointment.Domain.Models;


namespace Appointment.Application.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IRepository<Patient> _patientRepository;
    private readonly IPatientMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IPatientMapper mapper, IRepository<Patient> patientRepository)
    {
        _mapper = mapper;
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PatientResponse> Create(CreatePatientDto dto)
    {
        var patient = new Patient(
            Guid.NewGuid(),
            dto.FirstName,
            dto.LastName,
            dto.DateOfBirth,
            dto.Pesel,
            dto.Email,
            dto.PhoneNumber,
            dto.Address,
            dto.City,
            dto.Gender
        );
            
        
        _patientRepository.Add(patient);

        await _unitOfWork.CommitAsync();
        
        return _mapper.ToResponse(patient);
    }

    public async  Task<PatientResponse> Update(Guid patientId,PatientUpdateDto request)
    {
        var existing = await _patientRepository.GetById(patientId);

        if (existing == null)
        {
            throw new Exception("Patient not found");
        }
        
        existing.UpdateInfo(
           request.Name,
           request.Surname,
           existing.DateOfBirth,
           request.Pesel,
           existing.Email,
           existing.PhoneNumber,
           existing.Address,
           existing.City,
           existing.Gender
        );
        
        await _unitOfWork.CommitAsync();
        
        return _mapper.ToResponse(existing);
    }

    public async Task Delete(Guid patientId)
    {
        await _patientRepository.Delete(patientId);
        
        await _unitOfWork.CommitAsync();
    }

    public async Task<PatientResponse> GetById(Guid id)
    {
        var result = await _patientRepository.GetById(id);

        if (result == null)
        {
            throw new Exception("Patient not found");
        }
        
        return _mapper.ToResponse(result);
    }
}