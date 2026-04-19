using Appointment.Application.Contracts;
using Appointment.Application.Contracts.Adapter;
using Appointment.Application.Contracts.FilterContract;
using Appointment.Application.Common;
using Appointment.Application.DTOs.DoctorDTos;
using Appointment.Domain.Enums;
using Appointment.Domain.Models;

namespace Appointment.Application.Services;

public class MedicalProcessingService : IMedicalProcessingService
{
    private const string CriticalColor = "#FF0000";
    private const string NormalColor = "#00FF00";

    private readonly IEnumerable<ILabAdapter> _adapters;
    private readonly IMedicalPipeline _pipeline;
    private readonly IUnitOfWork _uow;

    public MedicalProcessingService(
        IEnumerable<ILabAdapter> adapters,
        IMedicalPipeline pipeline,
        IUnitOfWork uow)
    {
        _adapters = adapters;
        _pipeline = pipeline;
        _uow = uow;
    }

    public async Task<Result<DoctorDashboardDto>> ProcessLabData(string source, string rawData)
    {
        if (string.IsNullOrWhiteSpace(source))
            return Result<DoctorDashboardDto>.Failure("Source must be provided.");

        if (string.IsNullOrWhiteSpace(rawData))
            return Result<DoctorDashboardDto>.Failure("Raw data must be provided.");

        var adapter = _adapters.FirstOrDefault(candidate => candidate.CanHandle(source));

        if (adapter is null)
            return Result<DoctorDashboardDto>.Failure($"Source '{source}' is not supported.");

        var adaptationResult = adapter.Adapt(rawData);

        if (adaptationResult.IsFailure)
            return Result<DoctorDashboardDto>.Failure(adaptationResult.Error);

        var medicalResult = adaptationResult.Value;

        _pipeline.Process(medicalResult);
        await _uow.CommitAsync();

        return Result<DoctorDashboardDto>.Success(MapToDashboardDto(medicalResult));
    }

    public async Task<IReadOnlyList<DoctorDashboardDto>> GetSummaryAsync()
    {
        var results = await _uow.MedicalResultRepository.GetAll();

        return results
            .OrderByDescending(result => result.ProcessedAtUtc)
            .Select(MapToDashboardDto)
            .ToList();
    }

    private static DoctorDashboardDto MapToDashboardDto(MedicalResult result)
    {
        var hexColor = result.Status == MedicalStatus.Critical ? CriticalColor : NormalColor;

        return new DoctorDashboardDto(
            result.PatientName,
            $"{result.TestName}: {result.Value} {result.Unit}",
            result.Status.ToString(),
            hexColor);
    }
}