using Appointment.Application.Contracts;
using Appointment.Domain.Models;
using Appointment.Infrastructure.Data;

namespace Appointment.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly ApplicationDbContext _dbContext;
    
    public IRepository<Domain.Models.Appointment> AppointmentRepository { get; }
    
    public IRepository<Domain.Models.Patient> PatientRepository { get; }

    public IRepository<MedicalResult> MedicalResultRepository { get; }

    public UnitOfWork(
        ApplicationDbContext dbContext,
        IRepository<Domain.Models.Appointment> appointmentRepository,
        IRepository<Domain.Models.Patient> patientRepository,
        IRepository<MedicalResult> medicalResultRepository)
    {
        PatientRepository = patientRepository;
        AppointmentRepository = appointmentRepository;
        MedicalResultRepository = medicalResultRepository;
        _dbContext = dbContext;
    }
    
    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
    
}