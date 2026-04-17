using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost("Create/{patientId:guid}")]
    public async Task<IActionResult> CreateAsync([FromRoute] Guid patientId, [FromBody] CreateAppointmentDto dto)
    {
        var result = await _appointmentService.CreateAppointment(dto);
        return Ok(result);
    }

    [HttpGet("GetById/{patientId:guid}/{appointmentId:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid patientId, [FromRoute] Guid appointmentId)
    {
        var result = await _appointmentService.GetAppointmentById(patientId, appointmentId);
        return Ok(result);
    }

    [HttpDelete("Delete/{patientId:guid}/{appointmentId:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid patientId, [FromRoute] Guid appointmentId)
    {
        var result = await _appointmentService.DeleteAppointment(patientId, appointmentId);
        return Ok(result);
    }
}