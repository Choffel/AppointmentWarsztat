using Appointment.Application.Contracts;

namespace Appointment.Application.DSL;

public class DependencyRule<T1, T2> : IDependencyRule<T1, T2>
{
    private readonly Func<T1, T2, bool> _condition;
    private readonly Action<T1, T2> _action;

    public string Name { get; init; }
    public bool IsEnabled { get; private set; } = true;

    public DependencyRule(string name, Func<T1, T2, bool> condition, Action<T1, T2> action)
    {
        Name = name;
        _condition = condition;
        _action = action;
    }

    public bool IsMatch(T1 source, T2 target) => IsEnabled && _condition(source, target);

    public void Execute(T1 source, T2 target) => _action(source, target);
}