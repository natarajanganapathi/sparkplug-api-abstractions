namespace SparkPlug.Api.Abstractions;

public abstract class ApiResponse : IApiResponse
{
    protected ApiResponse(string? code = null, string? message = null)
    {
        Code = code;
        Message = message;
    }
    public string? Message { get; set; }
    public string? Code { get; set; }
}
