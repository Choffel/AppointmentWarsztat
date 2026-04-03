namespace Appointment.Application.Contracts;

public interface IDependencyEngine<T1,T2>
{
    IDependencyEngine<T1, T2> IfThen(
        Func<T1, T2, bool> condition,
        Action<T1, T2> action
    );

    IEnumerable<IDependencyRule<T1,T2>> GetRules();
    
    void Apply(T1 sourse, T2 target);    
}