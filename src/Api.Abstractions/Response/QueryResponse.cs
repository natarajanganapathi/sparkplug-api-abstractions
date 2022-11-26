namespace SparkPlug.Api.Abstractions;

public class QueryResponse<TEntity> : ApiResponse, IQueryResponse<TEntity>
{
    public QueryResponse(string? code = null, string? message = null, TEntity[]? data = default(TEntity[]), PageContext? pc = null, int? total = null) : base(code, message)
    {
        Data = data;
        Page = pc;
        Total = total;
    }
    public int? Total { get; set; }
    public IPageContext? Page { get; set; }
    public TEntity[]? Data { get; set; }
}

public static partial class Extensions
{
    #region QueryResponse
    public static IQueryResponse<TEntity> AddResponse<TEntity>(this IQueryResponse<TEntity> source, TEntity data)
    {
        return source.AddResponse(new TEntity[] { data });
    }
    public static IQueryResponse<TEntity> AddResponse<TEntity>(this IQueryResponse<TEntity> source, TEntity[] data)
    {
        source.Data = source.Data?.Concat(data).ToArray() ?? data;
        return source;
    }
    public static IQueryResponse<TEntity> AddPageContext<TEntity>(this IQueryResponse<TEntity> source, IPageContext pc)
    {
        source.Page = pc;
        return source;
    }
    public static IQueryResponse<TEntity> AddTotalRecord<TEntity>(this IQueryResponse<TEntity> source, int total)
    {
        source.Total = total;
        return source;
    }
    #endregion
}