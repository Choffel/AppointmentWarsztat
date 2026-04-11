using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Appointment.Domain.Models;

namespace Appointment.Application.Mappers;

public class PatientMapper : IPatientMapper
{
    public PatientResponse ToResponse(Patient patient)
    {
        ArgumentNullException.ThrowIfNull(patient);

        return new PatientResponse(
            patient.Id,
            patient.FirstName,
            patient.LastName,
            patient.Email,
            patient.PhoneNumber,
            patient.Gender,
            patient.DateOfBirth,
            patient.Address,
            patient.City,
            patient.Pesel
        );
    }
}