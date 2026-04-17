using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Appointment.Domain.Enums;


namespace Appointment.Application.Services;

public class AppointmentService : IAppointmentService  
{
    private readonly IUnitOfWork _uow;
    private readonly IAppointmentMapper _mapper;
    private readonly IRepository<Domain.Models.Appointment> _appointments;
    private readonly IRepository<Domain.Models.Patient> _patients;
    private readonly IAppointmentChecker _checker;

    public AppointmentService(IUnitOfWork uow, IAppointmentMapper mapper,
        IRepository<Domain.Models.Appointment> appointments,  IAppointmentChecker checker, IRepository<Domain.Models.Patient> patients)
    {
        _patients = patients;
        _checker = checker;
        _appointments = appointments;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<AppointmentResponseDto> CreateAppointment(CreateAppointmentDto dto)
    {
         // var patient = await _appointments.GetById(dto.PatientId);
         
         var patient = await  _patients.GetById(dto.PatientId);
        
        await _checker.HasOverlappingAppointmentAsync(dto.DoctorId, Guid.Empty, dto.Date,  dto.EndTime, dto.StartTime);
        
        if (patient == null)
            throw new ArgumentException("Patient not found");
        
        var appointment = new Domain.Models.Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,  
            Date = dto.Date,
            StartTime = TimeOnly.MinValue,  
            EndTime = TimeOnly.MinValue,      
            Description = "",  
            Status = AppointmentStatus.Pending
        };

        _appointments.Add(appointment);
        await _uow.CommitAsync();
        
        var fullAppointment = await _appointments.GetById(appointment.Id);
    
        return _mapper.ToResponseDto(fullAppointment);
    }

    public async Task<AppointmentResponseDto> GetAppointmentById(Guid patientId, Guid appointmentId)
    {
        
        var appointment = await _appointments.GetById(appointmentId);
        
        if (appointment?.PatientId != patientId)
            throw new UnauthorizedAccessException("Appointment not found for this patient");

        return _mapper.ToResponseDto(appointment);
    }

    public async Task<AppointmentResponseDto> DeleteAppointment(Guid patientId, Guid appointmentId)
    {
        var appointment = await _appointments.GetById(appointmentId);
        
        if (appointment?.PatientId != patientId)
            throw new UnauthorizedAccessException("Appointment not found for this patient");

        await  _appointments.Delete(appointmentId);
        await _uow.CommitAsync();

        return _mapper.ToResponseDto(appointment);  
    }
}