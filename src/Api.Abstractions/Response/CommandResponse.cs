namespace SparkPlug.Api.Abstractions;

public class CommandResponse<TEntity> : ApiResponse, ICommandResponse<TEntity>
{
    public CommandResponse(string? code = null, string? message = null, TEntity? data = default(TEntity)) : base(code, message)
    {
        Data = data;
    }
    public TEntity? Data { get; set; }
}