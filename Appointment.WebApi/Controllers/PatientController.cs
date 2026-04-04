using Appointment.Application.Contracts;
using Appointment.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase 
{
    private readonly IPatientService _patientService;
    
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePatientDto request)
    {
        var result = await _patientService.Create(request);
        return Ok(result);
    }

    [HttpPost("Update/{patientId:guid}")] 
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid patientId, [FromBody] PatientUpdateDto request)
    {
        var result = await _patientService.Update(patientId, request);    
        return Ok(result);
    }

    [HttpPost("Delete/{patientId:guid}")]  
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid patientId)
    { 
        await _patientService.Delete(patientId);  
        
        return NotFound();  
    }

    [HttpGet("GetPatientById/{patientId:guid}")]  
    public async Task<IActionResult> GetPatientByIdAsync([FromRoute] Guid patientId)
    {
        var result = await _patientService.GetById(patientId);  
        return result != null ? Ok(result) : NotFound();
    }
}