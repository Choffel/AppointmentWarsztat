using Appointment.Application.Contracts;
using Appointment.Application.Contracts.FilterContract;
using Appointment.Domain.Models;

namespace Appointment.Application.Services.Filters;

public class SaveFilter :IMedicalFilter
{
    private readonly IUnitOfWork _uow;

    public SaveFilter(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public void Execute(MedicalResult result)
    {
        _uow.MedicalResultRepository.Add(result);
    }
}