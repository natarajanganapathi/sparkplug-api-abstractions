namespace SparkPlug.Api.Abstractions;

public class CommandRequest<TEntity> : ApiRequest, ICommandRequest<TEntity>
{
    public CommandRequest(TEntity? data = default(TEntity))
    {
        Data = data;
    }
    public TEntity? Data { get; set; }
}