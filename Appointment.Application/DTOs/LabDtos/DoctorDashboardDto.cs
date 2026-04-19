namespace Appointment.Application.DTOs.DoctorDTos;

public record DoctorDashboardDto(
    string PatientName,
    string AnalysisInfo,
    string Status,
    string HexColor
    );