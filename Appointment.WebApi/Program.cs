using Appointment.Application.Contracts;
using Appointment.Application.Services;
using Appointment.Domain.Models;
using Appointment.Infrastructure.Data;
using Appointment.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSingleton<IDependencyEngine<Appointment.Domain.Models.Appointment, PlanTask>>(sp =>
{
    var engine = new DependencyEngine<Appointment.Domain.Models.Appointment, PlanTask>();
    
    engine
        .IfThen(
            (a, t) => t.Status == "Scheduled" && a.Date > DateTime.UtcNow,
            (a, t) => t.Status = "Completed")
        .IfThen(
            (a, t) => t.Status == "Completed" && a.Date > DateTime.UtcNow,
            (a, t) => t.Status = "Archived");

    return engine;
});

builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


var app = builder.Build();

app.MapOpenApi();


app.UseHttpsRedirection();

