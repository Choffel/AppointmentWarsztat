namespace Appointment.Application.Common;

public class Result
{
    protected Result(bool isSuccess, string error)
    {
        if (isSuccess && !string.IsNullOrWhiteSpace(error))
            throw new ArgumentException("Successful result cannot contain an error.", nameof(error));

        if (!isSuccess && string.IsNullOrWhiteSpace(error))
            throw new ArgumentException("Failure result must contain an error.", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public string Error { get; }

    public static Result Success() => new(true, string.Empty);

    public static Result Failure(string error) => new(false, error);
}

public sealed class Result<T> : Result
{
    private Result(T value) : base(true, string.Empty)
    {
        Value = value;
    }

    private Result(string error) : base(false, error)
    {
        Value = default!;
    }

    public T Value { get; }

    public static Result<T> Success(T value) => new(value);

    public static new Result<T> Failure(string error) => new(error);
}

