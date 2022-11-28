namespace SparkPlug.Api.Abstractions;

public class QueryRequest : ApiRequest, IQueryRequest
{
    public QueryRequest(string[]? select = null, IFilter? where = null, IOrder[]? sort = null, IPageContext? page = null)
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
    public IOrder[]? Sort { get; set; }
    public IPageContext? Page { get; set; }
}

public static partial class Extensions
{
    #region Select
    public static IQueryRequest Select(this IQueryRequest request, params string[] fields)
    {
        request.Select = request.Select?.Concat(fields).ToArray() ?? fields;
        return request;
    }
    #endregion
    #region Gorup
    public static IQueryRequest GroupBy(this IQueryRequest request, params string[] fields)
    {
        request.Group = request.Group?.Concat(fields).ToArray() ?? fields;
        return request;
    }
    #endregion
    #region Where
    public static IQueryRequest AndWhere(this IQueryRequest request, Func<CompositeFilter, CompositeFilter> filterAction)
    {
        return request.Where(filterAction(new CompositeFilter(CompositeOperator.And)));
    }
    public static IQueryRequest OrWhere(this IQueryRequest request, Func<CompositeFilter, CompositeFilter> filterAction)
    {
        return request.Where(filterAction(new CompositeFilter(CompositeOperator.Or)));
    }
    public static IQueryRequest Where(this IQueryRequest request, string field, FieldOperator op, object value)
    {
        return request.Where(new FieldFilter(field, op, value));
    }
    public static IQueryRequest Where(this IQueryRequest request, IFilter filter)
    {
        request.Where = request.Where == null ? filter : new CompositeFilter(CompositeOperator.And, request.Where, filter);
        return request;
    }
    #endregion
    #region Sort
    public static IQueryRequest Sort(this IQueryRequest request, string field, Direction direction)
    {
        return request.Sort(new Order(field, direction));
    }
    public static IQueryRequest Sort(this IQueryRequest request, Order order)
    {
        return request.Sort(new[] { order });
    }
    public static IQueryRequest Sort(this IQueryRequest request, Order[] orders)
    {
        request.Sort = request.Sort?.Concat(orders).ToArray() ?? orders;
        return request;
    }
    #endregion
    #region PageContext
    public static IQueryRequest Page(this IQueryRequest request, int pageNo, int pageSize)
    {
        return request.Page(new PageContext(pageNo, pageSize));
    }
    public static IQueryRequest Page(this IQueryRequest request, IPageContext page)
    {
        request.Page = page;
        return request;
    }
    public static IQueryRequest NextPage(this IQueryRequest request)
    {
        if (request.Page == null)
        {
            throw new InvalidOperationException("PageContext is not set");
        }
        return request.Page(request.Page.NextPage());
    }
    #endregion
}
