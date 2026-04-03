using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Appointment.Domain.Enums;
using Appointment.Domain.Models;


namespace Appointment.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IPatientRepository patientRepository,  IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = patientRepository;
    }

    public Task<Patient> Create(CreatePatientDto request)
    {
        var patientToCreate = new Patient
        {
            Id = Guid.NewGuid(),
            Name = request.FirstName,
            Surname = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Pesel = request.Pesel,
            Status = PatientStatus.Active
        };
        
        _patientRepository.Add(patientToCreate);
        
        _unitOfWork.SaveChangesAsync();
        
        return Task.FromResult(patientToCreate);
    }

    public async  Task<Patient> Update(Guid patientId,PatientUpdateDto request)
    {
        var exiting = await _patientRepository.GetById(patientId);

        if (exiting == null)
        {
            throw new Exception("Patient not found");
        }
        
        exiting.Name = request.Name;
        exiting.Surname = request.Surname;
        exiting.Pesel = request.Pesel;
        
        await _unitOfWork.SaveChangesAsync();
        return  await _patientRepository.Update(exiting);
    }

    public async Task Delete(Guid patientId)
    {
        await _patientRepository.DeleteAsync(patientId);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Patient> GetById(Guid id)
    {
        return await _patientRepository.GetById(id);
    }
}