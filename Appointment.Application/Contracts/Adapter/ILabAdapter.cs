using Appointment.Application.Common;
using Appointment.Domain.Models;

namespace Appointment.Application.Contracts.Adapter;

public interface ILabAdapter
{
    bool CanHandle(string source);

    Result<MedicalResult> Adapt(string data);
}