using Appointment.Application.Contracts;
using Appointment.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PlanTaskController : ControllerBase
{
    private readonly IDependencyEngine<Domain.Models.Appointment, PlanTask> _engine;

    public PlanTaskController(IDependencyEngine<Domain.Models.Appointment, PlanTask> engine)
    {
        _engine = engine;
    }


    [HttpPost("apply-rules")]
    public IActionResult ApplyRules([FromBody] PlanTask planTask,
        [FromBody] Domain.Models.Appointment appointment)
    {
        _engine.Apply(appointment, planTask);
        
        return Ok(planTask);
    }

    [HttpGet]
    public IActionResult GetStatus()
    {
        _engine.GetRules();
        return Ok();
    }
}