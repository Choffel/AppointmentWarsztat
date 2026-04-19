using Appointment.Application.Contracts;
using Appointment.Application.Contracts.Adapter;
using Appointment.Application.Contracts.FilterContract;
using Appointment.Application.DSL;
using Appointment.Application.Mappers;
using Appointment.Application.Services;
using Appointment.Application.Services.Filters;
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


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


builder.Services.AddScoped<IPatientMapper, PatientMapper>();
builder.Services.AddScoped<IAppointmentMapper, AppointmentMapper>();
builder.Services.AddScoped<IDoctorMapper, DoctorMapper>();


builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped(typeof(IDependencyEngine<,>), typeof(DependencyEngine<,>));
builder.Services.AddScoped<IAppointmentChecker, AppointmentChecker>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IMedicalProcessingService, MedicalProcessingService>();

builder.Services.AddScoped<ILabAdapter, LabAAdapter>();
builder.Services.AddScoped<ILabAdapter, LabBAdapter>();

builder.Services.AddScoped<IMedicalFilter, EvaluationFilter>();
builder.Services.AddScoped<IMedicalFilter, SaveFilter>();
builder.Services.AddScoped<IMedicalPipeline, MedicalPipeLine>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});


app.Run();

