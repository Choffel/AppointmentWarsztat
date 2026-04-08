namespace Appointment.Application.Contracts;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    
    Task<T> GetById(Guid id);
    
    T Add(T entity);
    
    T Update(T entity);
    
    Task Delete(Guid id);
}