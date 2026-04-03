using Appointment.Application.Contracts;

namespace Appointment.Application.Services;

public class DependencyEngine<T1, T2> : IDependencyEngine<T1, T2>
{
    private readonly List<IDependencyRule<T1, T2>> _rules = new();

    // 1. IfThen — добавляет правило
    public IDependencyEngine<T1, T2> IfThen(
        Func<T1, T2, bool> condition,
        Action<T1, T2> action)
    {
        _rules.Add(new Rule(condition, action));
        return this;
    }

    // 2. GetRules — возвращает правила
    public IEnumerable<IDependencyRule<T1, T2>> GetRules()
    {
        return _rules;
    }

    // 3. Apply — применяет подходящие правила
    public void Apply(T1 source, T2 target)
    {
        var applicable = _rules
            .Where(rule => rule.IsEnabled)
            .Where(rule => rule.IsMatch(source, target));

        foreach (var rule in applicable)
        {
            rule.Execute(source, target);
        }
    }

    // Внутренний приватный класс Rule — важно!
    private class Rule : IDependencyRule<T1, T2>
    {
        private readonly Func<T1, T2, bool> _condition;
        private readonly Action<T1, T2> _action;

        public Rule(
            Func<T1, T2, bool> condition,
            Action<T1, T2> action)
        {
            _condition = condition;
            _action = action;
            Name = "UnnamedRule";
            IsEnabled = true;
        }

        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public bool IsMatch(T1 source, T2 target)
            => _condition(source, target);

        public void Execute(T1 source, T2 target)
            => _action(source, target);
    }
}