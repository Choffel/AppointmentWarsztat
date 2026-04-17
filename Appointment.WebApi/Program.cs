using Appointment.Application.Contracts;
using Appointment.Application.Mappers;
using Appointment.Application.Services;
using Appointment.Domain.Models;
using Appointment.Infrastructure;
using Appointment.Infrastructure.Data;
using Appointment.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// builder.Services.AddSingleton<IDependencyEngine<Appointment.Domain.Models.Appointment, PlanTask>>(sp =>
// {
//     var engine = new DependencyEngine<Appointment.Domain.Models.Appointment, PlanTask>();
//     
//     engine
//         .IfThen(
//             (a, t) => t.Status == "Scheduled" && a.Date > DateTime.UtcNow,
//             (a, t) => t.Status = "Completed")
//         .IfThen(
//             (a, t) => t.Status == "Completed" && a.Date > DateTime.UtcNow,
//             (a, t) => t.Status = "Archived");
//
//     return engine;
// });


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


builder.Services.AddScoped<IPatientMapper, PatientMapper>();
builder.Services.AddScoped<IAppointmentMapper, AppointmentMapper>();
builder.Services.AddScoped<IDoctorMapper, DoctorMapper>();


builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentChecker, AppointmentChecker>();
builder.Services.AddScoped<IDoctorService, DoctorService>();


builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});


app.Run();

