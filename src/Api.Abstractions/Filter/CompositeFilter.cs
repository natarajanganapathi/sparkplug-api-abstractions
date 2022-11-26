namespace SparkPlug.Api.Abstractions;

public enum CompositeOperator
{
    And,
    Or
}

public class CompositeFilter : ICompositeFilter
{
    public CompositeFilter(CompositeOperator op = CompositeOperator.And, params IFilter[]? filters)
    {
        Op = op;
        Filters = filters;
    }
    public CompositeOperator Op { get; set; }
    public IFilter[]? Filters { get; set; }
}

public static partial class Extensions
{
    #region And - FieldOperator
    public static CompositeFilter AndEqual(this CompositeFilter source, string field, object value)
        => source.And(field, FieldOperator.Equal, value);
    public static CompositeFilter AndNotEqual(this CompositeFilter source, string field, object value)
        => source.And(field, FieldOperator.NotEqual, value);
    public static CompositeFilter AndGreaterThan(this CompositeFilter source, string field, object value)
        => source.And(field, FieldOperator.GreaterThan, value);
    public static CompositeFilter AndGreaterThanOrEqual(this CompositeFilter source, string field, object value)
        => source.And(field, FieldOperator.GreaterThanOrEqual, value);
    public static CompositeFilter AndLessThan(this CompositeFilter source, string field, object value)
        => source.And(field, FieldOperator.LessThan, value);
    public static CompositeFilter AndLessThanOrEqual(this CompositeFilter source, string field, object value)
        => source.And(field, FieldOperator.LessThanOrEqual, value);
    public static CompositeFilter AndIn(this CompositeFilter source, string field, object[] values)
        => source.And(field, FieldOperator.In, values);
    public static CompositeFilter AndNotIn(this CompositeFilter source, string field, object[] values)
        => source.And(field, FieldOperator.NotIn, values);
    #endregion
    #region And - UnaryOperator
    public static CompositeFilter AndIsNull(this CompositeFilter source, string field, bool exists = true)
        => source.And(field, UnaryOperator.IsNull);
    public static CompositeFilter AndIsNotNull(this CompositeFilter source, string field)
        => source.And(field,  UnaryOperator.IsNotNull);
    #endregion
    #region And
    public static CompositeFilter And(this CompositeFilter source, string field, UnaryOperator op)
    {
        return source.And(new UnaryFilter(field, op));
    }
    public static CompositeFilter And(this CompositeFilter source, string field, FieldOperator op, object value)
    {
        return source.And(new FieldFilter(field, op, value));
    }
    public static CompositeFilter And(this CompositeFilter source, IConditionFilter filter)
    {
        return (source.Op == CompositeOperator.And)
            ? AddConditionFilter(source, filter)
            : new CompositeFilter(CompositeOperator.And, source, filter);
    }
    public static CompositeFilter And(this CompositeFilter source, Func<CompositeFilter, CompositeFilter> filterAction)
    {
        var filter = filterAction(new CompositeFilter(CompositeOperator.And));
        return source.And(filter);
    }
    public static CompositeFilter And(this CompositeFilter source, CompositeFilter filter)
    {
        return source.Op == filter.Op
            ? MergeFilters(source, filter)
            : new CompositeFilter(CompositeOperator.And, source, filter);
    }
    #endregion
    #region Or - FieldOperator
    public static CompositeFilter OrEqual(this CompositeFilter source, string field, object value)
        => source.Or(field, FieldOperator.Equal, value);
    public static CompositeFilter OrNotEqual(this CompositeFilter source, string field, object value)
        => source.Or(field, FieldOperator.NotEqual, value);
    public static CompositeFilter OrGreaterThan(this CompositeFilter source, string field, object value)
        => source.Or(field, FieldOperator.GreaterThan, value);
    public static CompositeFilter OrGreaterThanOrEqual(this CompositeFilter source, string field, object value)
        => source.Or(field, FieldOperator.GreaterThanOrEqual, value);
    public static CompositeFilter OrLessThan(this CompositeFilter source, string field, object value)
        => source.Or(field, FieldOperator.LessThan, value);
    public static CompositeFilter OrLessThanOrEqual(this CompositeFilter source, string field, object value)
        => source.Or(field, FieldOperator.LessThanOrEqual, value);
    public static CompositeFilter OrIn(this CompositeFilter source, string field, object[] values)
        => source.Or(field, FieldOperator.In, values);
    public static CompositeFilter OrNotIn(this CompositeFilter source, string field, object[] values)
        => source.Or(field, FieldOperator.NotIn, values);
    #endregion
    #region Or - UnaryOperator
    public static CompositeFilter OrIsNull(this CompositeFilter source, string field)
        => source.Or(field, UnaryOperator.IsNull);
    public static CompositeFilter OrIsNotNull(this CompositeFilter source, string field)
        => source.Or(field, UnaryOperator.IsNotNull);
    #endregion
    #region Or
    public static CompositeFilter Or(this CompositeFilter source, string field, UnaryOperator op)
    {
        return source.Or(new UnaryFilter(field, op));
    }
    public static CompositeFilter Or(this CompositeFilter source, string field, FieldOperator op, object value)
    {
        return source.Or(new FieldFilter(field, op, value));
    }
    public static CompositeFilter Or(this CompositeFilter source, IConditionFilter filter)
    {
        return (source.Op == CompositeOperator.Or)
            ? AddConditionFilter(source, filter)
            : new CompositeFilter(CompositeOperator.And, source, filter);
    }
    public static CompositeFilter Or(this CompositeFilter source, Func<CompositeFilter, CompositeFilter> filterAction)
    {
        var filter = filterAction(new CompositeFilter(CompositeOperator.Or));
        return source.Or(filter);
    }
    public static CompositeFilter Or(this CompositeFilter source, CompositeFilter filter)
    {
        return source.Op == filter.Op
            ? MergeFilters(source, filter)
            : new CompositeFilter(CompositeOperator.Or, source, filter);
    }
    #endregion
    #region Common
    private static CompositeFilter MergeFilters(this CompositeFilter source, CompositeFilter filter)
    {
        if (filter.Filters != null)
        {
            source.Filters = source.Filters?.Concat(filter.Filters).ToArray() ?? new[] { filter };
        }
        return source;
    }
    private static CompositeFilter AddConditionFilter(this CompositeFilter source, IConditionFilter filter)
    {
        source.Filters = source.Filters?.Prepend(filter).ToArray() ?? new[] { filter };
        return source;
    }
    #endregion
}