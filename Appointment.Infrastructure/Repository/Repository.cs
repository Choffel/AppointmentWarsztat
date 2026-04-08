using Microsoft.EntityFrameworkCore;
using Appointment.Application.Contracts;
using Appointment.Infrastructure.Data;

namespace Appointment.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    protected DbSet<T> _dbSet;
    
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }


    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public  virtual T Add(T entity)
    {
        return  _dbSet.Add(entity).Entity;
    }

    public virtual  T Update(T entity)
    {
        return _dbSet.Update(entity).Entity;
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        if(entity != null) 
        {
            _dbSet.Remove(entity);
        }
    }
}