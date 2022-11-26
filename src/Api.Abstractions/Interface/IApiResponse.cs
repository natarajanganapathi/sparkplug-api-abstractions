namespace SparkPlug.Api.Abstractions;

public interface IApiResponse
{
    string? Code { get; set; }
    string? Message { get; set; }
}

public interface IErrorResponse : IApiResponse
{
    string? StackTrace { get; set; }
}

public interface IQueryResponse<TEntity> : IApiResponse
{
    int? Total { get; set; }
    IPageContext? Page { get; set; }
    TEntity[]? Data { get; set; }
}

public interface ICommandResponse<TEntity> : IApiResponse
{
    TEntity? Data { get; set; }
}

public interface ICompositeResponse : IApiResponse
{
    Dictionary<string, IApiResponse>? Data { get; set; }
}
