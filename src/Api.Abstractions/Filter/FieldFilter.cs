namespace SparkPlug.Api.Abstractions;

public enum FieldOperator
{
    Equal,
    NotEqual,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    In,
    NotIn
}

public class FieldFilter : IFieldFilter
{
    public FieldFilter(string field, FieldOperator op, object value)
    {
        Op = op;
        Field = field;
        Value = value;
    }
    public FieldOperator Op { get; set; }
    public string Field { get; set; }
    public object? Value { get; set; }
}
