namespace SparkPlug.Api.Abstractions;

public interface IApiRequest
{
    public string[]? Depends { get; set; }
}

public interface IQueryRequest<TEntity> : IApiRequest
{
    string[]? Select { get; set; }
    IFilter? Where { get; set; }
    IFilter? Having { get; set; }
    string[]? Group { get; set; }
    Order[]? Sort { get; set; }
    IPageContext? Page { get; set; }
}

public interface ICommandRequest<TEntity> : IApiRequest
{
    TEntity? Data { get; set; }
}

public interface ICompositeRequest : IApiRequest
{
    Dictionary<string, IApiRequest>? Requests { get; set; }
}