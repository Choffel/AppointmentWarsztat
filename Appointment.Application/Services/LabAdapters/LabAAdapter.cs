using Appointment.Application.Contracts.Adapter;
using Appointment.Application.Common;
using Appointment.Domain.Models;

namespace Appointment.Application.Services;

public class LabAAdapter : ILabAdapter
{
    public bool CanHandle(string source) => source.Equals("Lab_A", StringComparison.OrdinalIgnoreCase);

    public Result<MedicalResult> Adapt(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
            return Result<MedicalResult>.Failure("Raw data must be provided.");

        try
        {
            var json = System.Text.Json.JsonDocument.Parse(data).RootElement;

            if (!json.TryGetProperty("test_name", out var testNameProperty) ||
                !json.TryGetProperty("result", out var valueProperty) ||
                !json.TryGetProperty("scale", out var unitProperty))
            {
                return Result<MedicalResult>.Failure("Lab_A payload has invalid structure.");
            }

            var testName = testNameProperty.GetString();
            var unit = unitProperty.GetString();

            if (string.IsNullOrWhiteSpace(testName) || string.IsNullOrWhiteSpace(unit))
                return Result<MedicalResult>.Failure("Lab_A payload contains empty fields.");

            if (!valueProperty.TryGetDouble(out var value))
                return Result<MedicalResult>.Failure("Lab_A result value is invalid.");

            return Result<MedicalResult>.Success(new MedicalResult
            {
                TestName = testName,
                Value = value,
                Unit = unit
            });
        }
        catch (System.Text.Json.JsonException)
        {
            return Result<MedicalResult>.Failure("Lab_A payload is not valid JSON.");
        }
    }
}