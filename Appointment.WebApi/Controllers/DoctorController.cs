using Appointment.Application.Contracts;
using Appointment.Application.DTOs.DoctorDTos;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private readonly  IDoctorService _doctorService;
    
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var doctor = await _doctorService.GetByIdAsync(id);
        
        return Ok(doctor);
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateDoctorDto dto)
    {
        var doctor = await _doctorService.CreateAsync(dto);
        
        return Ok(doctor);
    }
    
    [HttpPost("Update/{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDoctorDto dto)
    {
        var doctor = await _doctorService.UpdateAsync(id, dto);
        
        return Ok(doctor);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var doctor = await _doctorService.DeleteAsync(id);
        
        return Ok(doctor);
    }
}