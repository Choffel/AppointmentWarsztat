using Appointment.Application.Contracts.FilterContract;
using Appointment.Domain.Models;

namespace Appointment.Application.Services;

public class MedicalPipeLine : IMedicalPipeline
{
    private readonly IReadOnlyCollection<IMedicalFilter> _filters;

    public MedicalPipeLine(IEnumerable<IMedicalFilter> filters)
    {
        _filters = filters.ToList();
    }

    public void Process(MedicalResult result)
    {
        foreach (var filter in _filters)
        {
            filter.Execute(result);
        }
    }
}