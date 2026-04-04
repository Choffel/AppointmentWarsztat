using Appointment.Application.Contracts;
using Appointment.Infrastructure.Data;

namespace Appointment.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public  async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}