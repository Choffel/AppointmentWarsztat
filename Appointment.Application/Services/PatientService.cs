using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Appointment.Domain.Models;


namespace Appointment.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public Task<Patient> Create(Patient patient)
    {
        var patientToCreate = new Patient
        {
            Id = Guid.NewGuid(),
            Name = patient.Name,
            Surname = patient.Surname,
            DateOfBirth = patient.DateOfBirth,
            Pesel = patient.Pesel,
            Status = patient.Status 
        };
        
        _patientRepository.Add(patientToCreate);
        
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
        
        return  await _patientRepository.Update(exiting);
    }

    public Task<Patient> Delete(Guid patientId)
    {
        var result = _patientRepository.GetById(patientId);
        
        if (result == null)
        {
            throw new Exception("Patient not found");
        }
        
        _patientRepository.Delete(patientId);

        return result;
    }

    public async Task<Patient> GetById(Guid id)
    {
        return await _patientRepository.GetById(id);
    }
}