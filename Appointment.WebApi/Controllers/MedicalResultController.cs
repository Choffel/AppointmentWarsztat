using Appointment.Application.Contracts;
using Appointment.Application.DTOs.DoctorDTos;
using Appointment.Application.DTOs.LabDtos;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalResultsController : ControllerBase
{
    private readonly IMedicalProcessingService _processingService;

    public MedicalResultsController(IMedicalProcessingService processingService)
    {
        _processingService = processingService;
    }

    [HttpPost("process")]
    public async Task<ActionResult<DoctorDashboardDto>> ProcessData([FromBody] LabRequestDto request)
    {
        var result = await _processingService.ProcessLabData(request.Source, request.RawData);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet("summary")]
    public async Task<ActionResult<IReadOnlyList<DoctorDashboardDto>>> GetSummary()
    {
        var summary = await _processingService.GetSummaryAsync();
        return Ok(summary);
    }
}