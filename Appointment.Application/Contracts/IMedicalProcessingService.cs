using Appointment.Application.Common;
using Appointment.Application.DTOs.DoctorDTos;

namespace Appointment.Application.Contracts;

public interface IMedicalProcessingService
{
    Task<Result<DoctorDashboardDto>> ProcessLabData(string source, string rawData);

    Task<IReadOnlyList<DoctorDashboardDto>> GetSummaryAsync();
}