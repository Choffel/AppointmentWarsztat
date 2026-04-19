using Appointment.Application.Contracts.Adapter;
using Appointment.Application.Common;
using Appointment.Domain.Models;
using System.Globalization;

namespace Appointment.Application.Services;

public class LabBAdapter : ILabAdapter
{
    public bool CanHandle(string source) => source.Equals("Lab_B", StringComparison.OrdinalIgnoreCase);

    public Result<MedicalResult> Adapt(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
            return Result<MedicalResult>.Failure("Raw data must be provided.");

        var fields = data
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(segment => segment.Split(':', 2))
            .Where(parts => parts.Length == 2)
            .ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim(), StringComparer.OrdinalIgnoreCase);

        if (!fields.TryGetValue("BADANIE", out var testName) ||
            !fields.TryGetValue("WYNIK", out var valueRaw) ||
            !fields.TryGetValue("JEDNOSTKA", out var unit))
        {
            return Result<MedicalResult>.Failure("Lab_B payload has invalid structure.");
        }

        if (string.IsNullOrWhiteSpace(testName) || string.IsNullOrWhiteSpace(unit))
            return Result<MedicalResult>.Failure("Lab_B payload contains empty fields.");

        if (!double.TryParse(valueRaw, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
            return Result<MedicalResult>.Failure("Lab_B result value is invalid.");

        return Result<MedicalResult>.Success(new MedicalResult
        {
            TestName = testName,
            Value = value,
            Unit = unit
        });
    }
}