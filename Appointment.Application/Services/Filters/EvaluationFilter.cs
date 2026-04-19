using Appointment.Application.Contracts.FilterContract;
using Appointment.Application.DSL;
using Appointment.Domain.Models;

namespace Appointment.Application.Services.Filters;

public class EvaluationFilter : IMedicalFilter
{
    private readonly MedicalNormsBuilder _norms;

    public EvaluationFilter()
    {
        _norms = new MedicalNormsBuilder()
            .ExpectRange("Glukoza", 70, 105)
            .ExpectRange("Cukier", 3.9, 5.8);
    }

    public void Execute(MedicalResult result)
    {
        result.Status = _norms.Check(result.TestName, result.Value);
    }
}