using Appointment.Application.Contracts;

namespace Appointment.Application.DSL;

public class DependencyEngine<T1, T2> : IDependencyEngine<T1, T2>
{
    private readonly List<IDependencyRule<T1, T2>> _rules = new();
    
    public IDependencyEngine<T1, T2> IfThen(Func<T1, T2, bool> condition, Action<T1, T2> action)
    {
        var ruleName = $"Rule {_rules.Count + 1}";
        _rules.Add(new DependencyRule<T1, T2>(ruleName, condition, action));
        return this;
    }

    public void Apply(T1 source, T2 target)
    {
        foreach (var rule in _rules)
        {
            if (rule.IsMatch(source, target))
            {
                rule.Execute(source, target);
            }
        }
    }

    public IEnumerable<IDependencyRule<T1, T2>> GetRules() => _rules;
}