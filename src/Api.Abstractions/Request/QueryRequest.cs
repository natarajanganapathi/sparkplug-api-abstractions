namespace SparkPlug.Api.Abstractions;

public class QueryRequest<TEntity> : ApiRequest, IQueryRequest<TEntity>
{
    public QueryRequest(string[]? select = null, IFilter? where = null, Order[]? sort = null, PageContext? page = null)
    {
        Select = select;
        Where = where;
        Sort = sort;
        Page = page;
    }
    public string[]? Select { get; set; }
    public IFilter? Where { get; set; }
    public IFilter? Having { get; set; }
    public string[]? Group { get; set; }
    public Order[]? Sort { get; set; }
    public IPageContext? Page { get; set; }
}

public static partial class Extensions
{
    #region Select
    public static IQueryRequest<TEntity> Select<TEntity>(this IQueryRequest<TEntity> request, params string[] fields)
    {
        request.Select = request.Select?.Concat(fields).ToArray() ?? fields;
        return request;
    }
    #endregion
    #region Gorup
    public static IQueryRequest<TEntity> GroupBy<TEntity>(this IQueryRequest<TEntity> request, params string[] fields)
    {
        request.Group = request.Group?.Concat(fields).ToArray() ?? fields;
        return request;
    }
    #endregion
    #region Where
    public static IQueryRequest<TEntity> AndWhere<TEntity>(this IQueryRequest<TEntity> request, Func<CompositeFilter, CompositeFilter> filterAction)
    {
        return request.Where(filterAction(new CompositeFilter(CompositeOperator.And)));
    }
    public static IQueryRequest<TEntity> OrWhere<TEntity>(this IQueryRequest<TEntity> request, Func<CompositeFilter, CompositeFilter> filterAction)
    {
        return request.Where(filterAction(new CompositeFilter(CompositeOperator.Or)));
    }
    public static IQueryRequest<TEntity> Where<TEntity>(this IQueryRequest<TEntity> request, string field, FieldOperator op, object value)
    {
        return request.Where(new FieldFilter(field, op, value));
    }
    public static IQueryRequest<TEntity> Where<TEntity>(this IQueryRequest<TEntity> request, IFilter filter)
    {
        request.Where = request.Where == null ? filter : new CompositeFilter(CompositeOperator.And, request.Where, filter);
        return request;
    }
    #endregion
    #region Sort
    public static IQueryRequest<TEntity> Sort<TEntity>(this IQueryRequest<TEntity> request, string field, Direction direction)
    {
        return request.Sort(new Order(field, direction));
    }
    public static IQueryRequest<TEntity> Sort<TEntity>(this IQueryRequest<TEntity> request, Order order)
    {
        return request.Sort(new[] { order });
    }
    public static IQueryRequest<TEntity> Sort<TEntity>(this IQueryRequest<TEntity> request, Order[] orders)
    {
        request.Sort = request.Sort?.Concat(orders).ToArray() ?? orders;
        return request;
    }
    #endregion
    #region PageContext
    public static IQueryRequest<TEntity> Page<TEntity>(this IQueryRequest<TEntity> request, int pageNo, int pageSize)
    {
        return request.Page(new PageContext(pageNo, pageSize));
    }
    public static IQueryRequest<TEntity> Page<TEntity>(this IQueryRequest<TEntity> request, IPageContext page)
    {
        request.Page = page;
        return request;
    }
    public static IQueryRequest<TEntity> NextPage<TEntity>(this IQueryRequest<TEntity> request)
    {
        if (request.Page == null)
        {
            throw new InvalidOperationException("PageContext is not set");
        }
        return request.Page(request.Page.NextPage());
    }
    #endregion
}
