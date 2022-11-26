namespace SparkPlug.Api.Abstractions;

public class CompositeResponse : ApiResponse, ICompositeResponse
{
    public CompositeResponse(string? code = null, string? message = null, Dictionary<string, IApiResponse>? data = null) : base(code, message)
    {
        Data = data;
    }
    public Dictionary<string, IApiResponse>? Data { get; set; }
}