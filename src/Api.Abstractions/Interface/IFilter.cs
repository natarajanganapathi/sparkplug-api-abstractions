namespace SparkPlug.Api.Abstractions;

public interface IFilter
{

}
public interface ICompositeFilter : IFilter
{
    CompositeOperator Op { get; set; }
    IFilter[]? Filters { get; set; }
}

public interface IConditionFilter : IFilter
{
    string Field { get; set; }
}

public interface IFieldFilter : IConditionFilter
{
    FieldOperator Op { get; set; }
    object? Value { get; set; }
}

public interface IUnaryFilter : IConditionFilter
{
    UnaryOperator Op { get; set; }
}
