namespace SparkPlug.Api.Abstractions;

public class ErrorResponse : ApiResponse, IErrorResponse
{
    public ErrorResponse(string? code = null, string? message = null, string? stackTrace = null) : base(code, message)
    {
        StackTrace = stackTrace;
    }
    public ErrorResponse(string? code, Exception? exception = null) : base(code, exception?.Message)
    {
#if DEBUG
        StackTrace = exception?.StackTrace;
#endif
    }
    public string? StackTrace { get; set; }
}