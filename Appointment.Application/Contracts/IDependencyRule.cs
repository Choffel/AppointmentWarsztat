namespace Appointment.Application.Contracts;

public interface IDependencyRule<T1,T2>
{
    string Name { get; }

    bool IsEnabled { get; }

    bool IsMatch(T1 source, T2 target);

    void Execute(T1 source, T2 target);
}