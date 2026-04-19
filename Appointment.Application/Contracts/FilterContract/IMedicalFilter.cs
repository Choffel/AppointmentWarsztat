using Appointment.Domain.Models;

namespace Appointment.Application.Contracts.FilterContract;

public interface IMedicalFilter
{
    void Execute(MedicalResult result);
}