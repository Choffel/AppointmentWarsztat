using Appointment.Domain.Enums;

namespace Appointment.Application.DSL;

public class MedicalNormsBuilder
{
    private readonly Dictionary<string, (double Min, double Max)> _rules = new();

      public MedicalNormsBuilder ForTest(string name) => this;

    public MedicalNormsBuilder ExpectRange(string testName, double min, double max)
    {
        _rules[testName.ToLower()] = (min, max);
        return this;
    }

    public MedicalStatus Check(string testName, double value)
    {
        if (!_rules.TryGetValue(testName.ToLower(), out var range)) 
            return MedicalStatus.Normal;

        return (value >= range.Min && value <= range.Max) 
            ? MedicalStatus.Normal 
            : MedicalStatus.Critical;
    }
}