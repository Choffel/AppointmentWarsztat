using Appointment.Domain.Models;

namespace Appointment.Application.Contracts.FilterContract;

public interface IMedicalPipeline
{
    void Process(MedicalResult result);
}


